using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public CanvasGroup blackScreenGroup;
    public TextMeshProUGUI transitionText;

    public string[] messages;
    public float textFadeDuration = 1f;

    private int currentIndex = 0;
    private bool isFading = false;

    void Start()
    {
        transitionText.text = "";
        blackScreenGroup.alpha = 1f;
        StartCoroutine(ShowText(messages[currentIndex]));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isFading)
        {
            if (currentIndex < messages.Length - 1)
            {
                currentIndex++;
                StartCoroutine(ShowText(messages[currentIndex]));
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

IEnumerator ShowText(string message)
{
    isFading = true;
    transitionText.text = "";
    transitionText.alpha = 1f;

    foreach (char c in message)
    {
        transitionText.text += c;
        yield return new WaitForSeconds(0.03f);
    }

    isFading = false;
}

}