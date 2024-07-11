using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("UI elements")]
    public Slider soundSlider;
    public Slider musicSlider;

    [Header("Audio sources")]
    public AudioSource soundSource;
    public AudioSource musicSource;

    private const string SoundVolKey = "SoundVolume";
    private const string MusicVolKey = "MusicVolume";

    private void Start()
    {
        float savedSoundVolume = PlayerPrefs.GetFloat(SoundVolKey, 1f);
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolKey, 1f);

        soundSlider.value = savedSoundVolume;
        musicSlider.value = savedMusicVolume;

        soundSource.volume = savedSoundVolume;
        musicSource.volume = savedMusicVolume;

        soundSlider.onValueChanged.AddListener(SetSoundVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetSoundVolume(float volume)
    {
        soundSource.volume = volume;
        PlayerPrefs.SetFloat(SoundVolKey, volume);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(MusicVolKey, volume);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
