using System.Collections;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class WordScramble : MonoBehaviour
{
    public Letter[] collectedLetters;
    public GameObject[] letterHoldersGO;
    [SerializeField] private Letter[] letterHolders;
    public int crtIndex;
    public bool check;
    public int maxHolders;
    public int nrParts;
    public bool complete;
    public TextMeshProUGUI textMessage;
    public GameObject panel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHolders = letterHoldersGO.Length;
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (check == true)
        {
            check = false;
            Check();
        }
    }

    public void PlaceLetter(Letter letter)
    {
        if (crtIndex < nrParts)
        {
            letterHoldersGO[crtIndex].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
            letter.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            //.GetChild()GetComponent<Image>().sprite = letter.sprite;
            letterHolders[crtIndex++] = letter;
            if (crtIndex == nrParts)
                Check();
        }        
    }

    public bool Check()
    {
        for (int i = 0; i < nrParts; i++)
        {
            if (letterHolders[i].index != i)
            {
                ResetGame();
                complete = false;
                StartCoroutine(TryAgain());
                return false;

            }
        }
        complete = true;
        textMessage.text = "THE WORD IS CORRECT!";
        StartCoroutine(ClosePanelTime());
        //ResetGame();
        return true;
    }

    private void ResetGame()
    {
        for (int i = 0; i < letterHolders.Length; i++)
        {
            letterHoldersGO[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        }
        textMessage.text = "ARRANGE THE LETTERS IN THE CORRECT ORDER TO FORM THE WORD";
        crtIndex = 0;
    }

    private IEnumerator TryAgain()
    {
        textMessage.text = "TRY AGAIN!";
        yield return new WaitForSeconds(1);
        textMessage.text = "ARRANGE THE LETTERS IN THE CORRECT ORDER TO FORM THE WORD";
    }


    private IEnumerator ClosePanelTime()
    {
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        ResetGame();
    }
}
