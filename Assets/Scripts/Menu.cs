using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
    public GameObject storyPanel;
    public GameObject optionsPanel;
    public GameObject backgroundPanel;

    public AudioSource audioSource;
    public AudioClip clickSound;

    private CanvasGroup canvasGroup;
    private CanvasGroup optionsCanvasGroup;

    private bool hasFadedStory = false;
    private bool hasFadedOptions = false;

    void Start()
    {
        canvasGroup = storyPanel.GetComponent<CanvasGroup>();
        optionsCanvasGroup = optionsPanel.GetComponent<CanvasGroup>();

        storyPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void PlayAndLoad()
    {
        // 🔊 Redă doar sunetul de click
        if (audioSource && clickSound)
        {
            audioSource.clip = clickSound;
            audioSource.Play();
        }
    }

    private IEnumerator FadeInPanel(GameObject panel, CanvasGroup cg)
    {
        panel.SetActive(true);
        cg.alpha = 0f;

        float duration = 1f;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(0f, 1f, t / duration);
            yield return null;
        }

        cg.alpha = 1f;
    }

    public void ShowStory() 
    {
        backgroundPanel.SetActive(false);
        if (!hasFadedStory)
        {
            hasFadedStory = true;
            StartCoroutine(FadeInPanel(storyPanel, canvasGroup));
        }
        else
        {
            storyPanel.SetActive(true);
        }
    }

    public void ShowOptions()
    {
        backgroundPanel.SetActive(false);
        if (!hasFadedOptions)
        {
            hasFadedOptions = true;
            StartCoroutine(FadeInPanel(optionsPanel, optionsCanvasGroup));
        }
        else
        {
            optionsPanel.SetActive(true);
        }
    }
}
