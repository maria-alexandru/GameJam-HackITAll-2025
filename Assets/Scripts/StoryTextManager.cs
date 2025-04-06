using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryTextManager : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public float fadeDuration = 1f; 
    public string[] phrases;           

    private int currentIndex = 0;
    private bool isFading = false;
    public bool enableSound = false;
    public AudioSource phraseAudio;

    void Start()
    {
        storyText.text = "";
        storyText.alpha = 0;

        if (phrases.Length > 0)
        {
          StartCoroutine(ShowPhrase(phrases[0]));
          currentIndex = 1;
        } 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isFading && currentIndex < phrases.Length)
        {
            StartCoroutine(ShowPhrase(phrases[currentIndex]));
            currentIndex++;
        }
        if (Input.GetKeyDown(KeyCode.Return) && currentIndex == phrases.Length - 1)
        {
            SceneManager.LoadScene("Lvl1");
        }
    }

    IEnumerator ShowPhrase(string phrase)
    {
        if (enableSound && phraseAudio != null)
            phraseAudio.Play();
        isFading = true;
        storyText.text = phrase;
        storyText.alpha = 0f;

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            storyText.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        storyText.alpha = 1f;
        isFading = false;
    }
}
