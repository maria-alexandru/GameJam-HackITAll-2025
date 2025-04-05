using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public Toggle musicToggle;
    public Slider musicSlider;

    public Toggle sfxToggle;
    public Slider sfxSlider;

    void Start()
    {
        musicSlider.value = musicSource.volume;
        sfxSlider.value = sfxSource.volume;

        musicToggle.isOn = musicSource.mute == false;
        sfxToggle.isOn = sfxSource.mute == false;

        musicToggle.onValueChanged.AddListener(ToggleMusic);
        sfxToggle.onValueChanged.AddListener(ToggleSFX);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void ToggleMusic(bool isOn)
    {
        musicSource.mute = !isOn;
    }

    void ToggleSFX(bool isOn)
    {
        sfxSource.mute = !isOn;
    }

    void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
