using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Slider musicSlider;

    private AudioSource musicSource;

    void Start()
    {
        musicSource = GameObject.Find("MusicManager").GetComponent<AudioSource>();

        musicSlider.value = musicSource.volume;
        musicToggle.isOn = musicSource.volume > 0;

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        musicToggle.onValueChanged.AddListener(ToggleMusic);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicToggle.isOn = volume > 0;
    }

    public void ToggleMusic(bool isOn)
    {
        musicSource.volume = isOn ? musicSlider.value : 0f;
    }
}
