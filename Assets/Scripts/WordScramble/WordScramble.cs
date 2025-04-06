using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordScramble : MonoBehaviour
{
    public Letter[] collectedLetters;
    public GameObject[] letterHoldersGO;
    [SerializeField] private Letter[] letterHolders;
    public int crtIndex;
    public bool check;
    public int maxHolders;
    public int nrParts;
    public int nrCollected;
    public bool complete;
    public TextMeshProUGUI textMessage;
    public GameObject panel;
    public GameObject memoryPanel;
    public GameObject timeButton;
    public TextMeshProUGUI memoryText;
    public bool isOpen;

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

    public void AddCollectedLetter()
    {
        if(InteractionManager.selectedItems == null) {
            Debug.Log("null list");
            return;
        }

        // Debug.LogError(InteractionManager.selectedItems.Count);
        Letter letter;
        for (int i = 0; i < InteractionManager.selectedItems.Count; i++)
        {
            //Debug.Log(InteractionManager.selectedItems.ElementAt(i) + "");
            //Debug.Log(InteractionManager.selectedItems.ElementAt(i).GetComponent<Letter>().GetText());

             letter = InteractionManager.selectedItems.ElementAt(i).GetComponent<Letter>();
            if (letter.GetText() == "")
            {
                InteractionManager.selectedItems.Remove(InteractionManager.selectedItems.ElementAt(i));
                i--;
                continue;
            }
            collectedLetters[i].index = letter.index;
            collectedLetters[i].SetText(letter.GetText());
            TextMeshProUGUI textM = collectedLetters[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            textM.text = collectedLetters[i].GetText();
            collectedLetters[i].gameObject.GetComponent<Button>().interactable = true;


            //Debug.Log("--" + letter.GetText());
            //Debug.Log("---" + collectedLetters[i].GetText());
            //Debug.Log("!" + collectedLetters[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().name);
        }
        nrCollected = InteractionManager.selectedItems.Count;
    }

    public void PlaceLetter(Letter letter)
    {
        if (nrCollected == nrParts && crtIndex < nrParts)
        {
            letterHoldersGO[crtIndex].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
            letter.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            letter.gameObject.GetComponent<Button>().interactable = false;
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
        StartCoroutine(Correct());
        //ResetGame();
        return true;
    }

    private void ResetGame()
    {
        for (int i = 0; i < letterHolders.Length; i++)
        {
            //Debug.Log("d");
            collectedLetters[i].gameObject.GetComponent<Button>().interactable = false;
            letterHoldersGO[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            collectedLetters[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        }
        textMessage.text = "ARRANGE THE LETTERS IN THE CORRECT ORDER TO FORM THE WORD";
        crtIndex = 0;
        AddCollectedLetter();
    }

    private IEnumerator TryAgain()
    {
        textMessage.text = "TRY AGAIN!";
        yield return new WaitForSeconds(1);
        textMessage.text = "ARRANGE THE LETTERS IN THE CORRECT ORDER TO FORM THE WORD";
    }

    private IEnumerator Correct()
    {
        textMessage.text = "THE WORD IS CORRECT!";
        yield return new WaitForSeconds(1);
        OpenMemoryPanel();
        //StartCoroutine(ClosePanelTime());
        //textMessage.text = "ARRANGE THE LETTERS IN THE CORRECT ORDER TO FORM THE WORD";
    }


    private IEnumerator ClosePanelTime()
    {
        yield return new WaitForSeconds(1);
        ClosePanel();
    }

    public void ClosePanel()
    {
        timeButton.SetActive(true);
        isOpen = false;
        panel.SetActive(false);
    }

    public void OpenPanel()
    {       
        if (isOpen == false)
        {
            timeButton.SetActive(false);
            //Debug.LogError("d");
            ResetGame();
            isOpen = true;
            AddCollectedLetter();
            panel.SetActive(true);
        }
    }

    public void OpenMemoryPanel()
    {
        timeButton.SetActive(false);
        memoryPanel.SetActive(true);
        memoryText.gameObject.SetActive(true);
    }

    public void GoToNextScene()
    {
        if (SceneManager.GetActiveScene().name == "Lvl1")
        {
           SceneManager.LoadScene("Lvl22");
        }

        if (SceneManager.GetActiveScene().name == "Lvl22")
        {
           SceneManager.LoadScene("Lvl3");
        }

        if (SceneManager.GetActiveScene().name == "Lvl3")
        {
           SceneManager.LoadScene("Puzzle");
        }
    }
}
