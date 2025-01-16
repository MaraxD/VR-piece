using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DropletColliderInteraction : MonoBehaviour
{
	public GameObject currentContactObject;
	public GameObject nextContactObject;

	public AudioSource contactAudio;

	public ParticleSystem rainParticleSystem;
	public ParticleSystem onContactParticleSystem;

	//public static float rateOverTimeIncrease = 100f;
	public static int timesTouchedCollider = 0;

	void OnTriggerEnter(Collider other)
	{

		onContactParticleSystem.Play();
		contactAudio.Play(); //cand voi avea audio ul

		currentContactObject.SetActive(false);
		nextContactObject.SetActive(true);

		timesTouchedCollider++;

		if (timesTouchedCollider == 1)
		{
			var emission = rainParticleSystem.emission;
			emission.rateOverTime = 600f;
		}

		if (timesTouchedCollider == 2)
		{
			var emission = rainParticleSystem.emission;
			emission.rateOverTime = 800f;
		}

		if (timesTouchedCollider == 3)
		{
			var emission = rainParticleSystem.emission;
			emission.rateOverTime = 1000f;
		}





		//currentContactObject.SetActive(false);
		//nextContactObject.SetActive(true);

		//var emission = rainParticleSystem.emission;
		//emission.rateOverTime = rateOverTimeIncrease;

		//Debug.Log("drop touched");


		//rateOverTimeIncrease += 100; //with every touch of a droplet, increase the droplets

		//if (timesTouchedCollider == 4)
		//{
		//	// scene transition
		//	SceneManager.LoadScene("<name of the scene>");
		//}
	}
}