using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRain : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;

    void playRain()
    {
        rainParticleSystem.Play();
    }


}
