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

	/*void Update()
    {
        // if the user did not touch the droplet, after a certain period, make it dissapear and go to the next droplet
        if (currentContactObject.activeSelf)
        {
			// get the current time when the object activates
			dropStartTime = Time.time;
			Debug.Log("current frame:" + Time.time);
            if (Time.time - dropStartTime > 20f)
            {
				currentContactObject.SetActive(false);
				nextContactObject.SetActive(true);
			}

		}
    }*/

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