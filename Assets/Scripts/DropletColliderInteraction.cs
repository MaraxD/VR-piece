using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropletColliderInteraction : MonoBehaviour
{
	public GameObject currentContactObject;
	public GameObject nextContactObject;

	public AudioSource waterSound;

	public ParticleSystem rainParticleSystem;
	public ParticleSystem onContactParticleSystem;

	public static float rateOverTimeIncrease = 100f;
	public static int timesTouchedCollider = 0;

	private float dropStartTime;
	private float waitTime=2f;

    private void Start()
    {
		dropStartTime = Time.time; //get the current time (seconds) when the object appears
	}

    void Update()
    {
        // if the user did not touch the droplet, after a certain period, make it dissapear and go to the next droplet
		Debug.Log("time elapsed:" + (Time.time - dropStartTime));
        if (Time.time - dropStartTime > 10f)
        {
            currentContactObject.SetActive(false);
            nextContactObject.SetActive(true);
        }

    }

    void OnTriggerEnter(Collider other)
	{

		onContactParticleSystem.Play();
		waterSound.Play(); // replace it with bits from the song

		currentContactObject.SetActive(false);
		nextContactObject.SetActive(true);

        if (timesTouchedCollider < 7)
        {
			rateOverTimeIncrease += 500f;
			var emission = rainParticleSystem.emission;
			emission.rateOverTime = rateOverTimeIncrease;
        }
        else
        {
			// wait for 7 seconds and transition to the next scene
			nextContactObject.SetActive(false);
			Invoke("DelayedTransition", waitTime);
		}

		timesTouchedCollider++;
	}

	void DelayedTransition()
    {
		SceneManager.LoadScene("Rain");
	}
}