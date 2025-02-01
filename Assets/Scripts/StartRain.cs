using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRain : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    public GameObject firstDrop;
    public AudioSource instructionsSound;
    public float waitTime=25.7f;

    void playRain()
    {
        rainParticleSystem.Play();
        instructionsSound.Play();

        StartCoroutine(waitForSound(firstDrop, instructionsSound));
    }

    public static IEnumerator waitForSound(GameObject drop, AudioSource audioSource)
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        drop.SetActive(true); //after audio has finished playing, reveal the first drop
    }
}