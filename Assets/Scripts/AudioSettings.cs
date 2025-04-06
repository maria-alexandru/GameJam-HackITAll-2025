using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Slider musicSlider;
    public Image musicImage;

    public Toggle sfxToggle;
    public Slider sfxSlider;
    public Image sfxImage;

    public Color activeColor = Color.white;
    public Color mutedColor = new Color(0.3f, 0.3f, 0.3f); // gri închis

    private AudioSource musicSource;
    private AudioSource sfxSource;

    void Start()
    {
        musicSource = GameObject.Find("MusicManager").GetComponent<AudioSource>();
        sfxSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();

        // Inițializare Music
        musicSlider.value = musicSource.volume;
        musicToggle.isOn = musicSource.volume > 0;
        UpdateColor(musicImage, musicToggle.isOn);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        musicToggle.onValueChanged.AddListener(ToggleMusic);

        // Inițializare SFX
        sfxSlider.value = sfxSource.volume;
        sfxToggle.isOn = sfxSource.volume > 0;
        UpdateColor(sfxImage, sfxToggle.isOn);

        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        sfxToggle.onValueChanged.AddListener(ToggleSFX);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        bool isOn = volume > 0;
        musicToggle.isOn = isOn;
        UpdateColor(musicImage, isOn);
    }

    public void ToggleMusic(bool isOn)
    {
        musicSource.volume = isOn ? musicSlider.value : 0f;
        UpdateColor(musicImage, isOn);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        bool isOn = volume > 0;
        sfxToggle.isOn = isOn;
        UpdateColor(sfxImage, isOn);
    }

    public void ToggleSFX(bool isOn)
    {
        sfxSource.volume = isOn ? sfxSlider.value : 0f;
        UpdateColor(sfxImage, isOn);
    }

    private void UpdateColor(Image img, bool isOn)
    {
        if (img != null)
        {
            img.color = isOn ? activeColor : mutedColor;
        }
    }
}
