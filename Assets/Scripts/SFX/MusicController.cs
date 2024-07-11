using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private float maxVol;
    public float minVol;
    private AudioSource source;
    public AudioClip clip;

    public float fadeInDuration;
    public float fadeOutDuration;

    private IEnumerator fadeIn;
    private IEnumerator fadeOut;

    public static MusicController instance;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        maxVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
    }

    private void Start()
    {
        StartMusic();
    }

    public void StartMusic()
    {
        if(fadeOut != null)
            StopCoroutine(fadeOut);

        source.clip = clip;
        source.Play();

        //fadeIn = FadeIn(source, fadeInDuration, maxVol);
        //StartCoroutine(fadeIn);
    }

    public void StopMusic()
    {
        fadeOut = FadeOut(source, fadeOutDuration, minVol);
        if(source.isPlaying)
        {
            //StopCoroutine(fadeIn);
            StartCoroutine(fadeOut);
        }
    }

    IEnumerator FadeIn (AudioSource aSource, float duration, float targetVol)
    {
        float timer = 0f;
        float currentVolume = aSource.volume;
        float targetValue = Mathf.Clamp(targetVol, minVol, maxVol);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float newVolume = Mathf.Lerp(currentVolume, targetValue, timer / duration);
            aSource.volume = newVolume;
            yield return null;
        }
    }

    IEnumerator FadeOut(AudioSource aSource, float duration, float targetVol)
    {
        float timer = 0f;
        float currentVolume = aSource.volume;
        float targetValue = Mathf.Clamp(targetVol, minVol, maxVol);

        while (aSource.volume > 0)
        {
            timer += Time.deltaTime;
            float newVolume = Mathf.Lerp(currentVolume, targetValue, timer / duration);
            aSource.volume = newVolume;
            yield return null;
        }
    }
}
