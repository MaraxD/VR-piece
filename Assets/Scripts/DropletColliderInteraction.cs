using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropletColliderInteraction : MonoBehaviour
{
	public GameObject currentContactObject;
	public GameObject nextContactObject;

	public AudioSource waterSound;
	public AudioSource missedDropSound;
	public AudioSource failedAttemptSound;

	public ParticleSystem rainParticleSystem;
	public ParticleSystem onContactParticleSystem;

	public static float rateOverTimeIncrease = 100f;
	public static int timesTouchedCollider = 0;
	public int numberOfRaindrops;

	private float dropStartTime;
	private float waitTime=2f;

	private bool hasMissedDrop;


    private void Start()
    {
		dropStartTime = Time.time; //get the current time (seconds) when the object appears
		hasMissedDrop = false;
	}

    void Update()
    {
        // if the user did not touch the droplet, after a certain period, make it dissapear and go to the next droplet
		Debug.Log("time elapsed:" + (Time.time - dropStartTime));
        if (!hasMissedDrop && Time.time - dropStartTime >= 6f)
        {
			hasMissedDrop = true;

			StartCoroutine(HandleMissedDrop());
		}

	}

	IEnumerator HandleMissedDrop()
	{
		Animator dropAnimation = GetComponent<Animator>();
		dropAnimation.enabled = false;

		transform.position = new Vector3(transform.position.x, -3.564f, transform.position.z); // hide under the map, dont make it inactive

        if (!currentContactObject.name.Equals("Drop8"))
        {
			missedDropSound.Play();
			yield return new WaitWhile(() => missedDropSound.isPlaying); // wait for the sound to finish
			nextContactObject.SetActive(true); //after audio has finished playing, reveal the next drop
        }
        else
        {
			if (timesTouchedCollider <= numberOfRaindrops / 2)
            {
				Debug.Log("you failed");
				failedAttemptSound.Play();
            }
            else
            {
				Invoke("DelayedTransition", waitTime);
			}

		}
		
	}

	void OnTriggerEnter(Collider other)
	{
		StopAllCoroutines(); // stop the disappearance countdown if touched

		onContactParticleSystem.Play();
		waterSound.Play(); // replace it with bits from the song

		currentContactObject.SetActive(false);
		nextContactObject.SetActive(true);

		if(!currentContactObject.name.Equals("Drop8"))
        {
			rateOverTimeIncrease += 500f;
			var emission = rainParticleSystem.emission;
			emission.rateOverTime = rateOverTimeIncrease;
        }
        else
        {
			if(timesTouchedCollider <= numberOfRaindrops / 2)
            {
				// we remain in the current scene, user has failed to touch all of them and create the song
				Debug.Log("you failed");
				failedAttemptSound.Play();
			}
            else
            {
				// wait for 7 seconds and transition to the next scene
				nextContactObject.SetActive(false);
				Invoke("DelayedTransition", waitTime);
			}
        }

		timesTouchedCollider++;
	}

	void DelayedTransition()
    {
		SceneManager.LoadScene("Rain");
	}
}