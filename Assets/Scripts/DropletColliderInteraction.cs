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

        if (timesTouchedCollider < 8)
        {
			rateOverTimeIncrease += 500f;
			var emission = rainParticleSystem.emission;
			emission.rateOverTime = rateOverTimeIncrease;
        }
        else
        {
			// hide the last object and go to the next scene
			currentContactObject.SetActive(false);
			SceneManager.LoadScene("Rain");
		}

		timesTouchedCollider++;
	}
}