using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSoundtrack : MonoBehaviour
{
    public AudioSource soundtrack, narratorVoice;
    public float fadeDuration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playSoundtrack(narratorVoice));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator playSoundtrack(AudioSource narratorAudio)
    {
        yield return new WaitWhile(() => narratorAudio.isPlaying); // wait for the sound to finish
        soundtrack.Play();

        //fade-in transition
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            soundtrack.volume = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        soundtrack.volume = 1f;
    }
}
