using UnityEngine;
using UnityEngine.Audio;

public class PlayMusicInGame : MonoBehaviour
{
    AudioSource sfxSource;
    public AudioClip clickSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    public void PlayAndLoad()
    {
        // Reda doar sunetul de click
        if (sfxSource && clickSound)
        {
            sfxSource.clip = clickSound;
            sfxSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
