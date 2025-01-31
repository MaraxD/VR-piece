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

        // wait a couple of seconds, start showing the first drop
        Invoke("DelayedAppearance", waitTime);
    }

    void DelayedAppearance()
    {
        firstDrop.SetActive(true);
    }
}