using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRain : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    public GameObject firstDrop;
    public int waitTime=105;

    void playRain()
    {
        SceneManager.LoadScene("Rain");

        // rainParticleSystem.Play();

        // // wait a couple of seconds, start showing the first drop
        // StartCoroutine(Waiter());
        // firstDrop.SetActive(true);
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(waitTime);

    }


}
