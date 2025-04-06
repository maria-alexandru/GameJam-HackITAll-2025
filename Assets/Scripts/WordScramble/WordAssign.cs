using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordAssign : MonoBehaviour
{
    private string[] wordsHappy = { "stillness", "warmth", "routine", "solace", "gentleness", "comfort", "serenity", "tenderness",
                                    "softness", "quietude", "familiarity", "memory", "reverie", "fragility"};
    private string[] wordsSuicide = { "despair", "failure", "guilt", "collapse", "burden", "regret", "finality", "shame",
                                        "isolation", "escape", "relief", "decision", "blame", "silence", "release" };
    private string[] wordsMurder = { "betrayal", "poison", "premeditation", "jealousy", "manipulation", "hatred", "control", "deception",
                                        "premonition", "retribution", "resentment", "intent", "justice", "silhouettes", "porcelain" };

    private string[] endingHappy = { "The apartment was filled with a stillness that felt almost sacred",
                                     "She remembered the warmth of the tea more than the words they said",
                                     "It was always the same three things: a book, a cup, a quiet sigh",
                                     "In the rain tapping on the window, she found a kind of solace",
                                     "Everything in that morning moved with gentleness except the silence",
                                     "The chair still held the shape of her body, like a memory of comfort",
                                     "For a moment, even the ghosts seemed to respect the serenity",
                                     "Her touch lingered on the page with a forgotten tenderness",
                                     "There was a softness in the air, as if nothing terrible had ever happened",
                                     "Quietude wasn't the absence of noise, but the presence of peace",
                                     "There was comfort in familiarity and danger in breaking it",
                                     "Not all memories are loud. Some just hum in the background",
                                     "She floated through the room like a reverie, half-real, half-regret",
                                     "Peace, she learned, is as fragile as porcelain and just as easy to shatter"
                                    };
    private string[] endingSuicide = { "He smiled the whole time. That was the real betrayal",
                                     "The tea was sweet. Too sweet. Like it wanted to hide something",
                                     "Guilt clung to the walls like smoke never gone, just unseen.",
                                     "The company fell quietly. He followed, just as silently",
                                     "Every headline felt like a weight he couldn't put down",
                                     "Regret came in waves, but this time, he didn't try to swim",
                                     "He folded the suit one last time like it mattered",
                                     "The reflection in the window was sharper than any words could be",
                                     "The calls stopped. The emails stopped. Only silence kept ringing",
                                     "Maybe it wasn't peace he wanted. Just an end to the noise",
                                     "He told himself it would be a relief. No more weight. No more eyes",
                                     "It didn't feel like giving up. It felt like finishing",
                                     "He carried the blame in every breath. Until there were no more",
                                     "Silence wasn't scary anymore. It was inviting",
                                     "There's a moment, right before, when everything goes still. That was the release"
                                    };
    private string[] endingMurder = { "The papers were still on the desk, soaked in the despair he tried to hide",
                                     "He whispered it like a curse: I failed them all",
                                     "He chose the confectionery because it was quiet. Because no one would hear",
                                     "He said he was proud. But his hands were shaking from jealousy",
                                     "The conversation was gentle until you replayed it, glitch by glitch",
                                     "You don't kill someone you hate. You kill someone you once loved",
                                     "Even the sugar packet felt like part of the plan",
                                     "The betrayal didn't taste bitter. It tasted like strawberry cream",
                                     "There was a tremble in the spoon. Maybe his soul already knew",
                                     "You stole my future. That was the last thing he whispered, after the last sip",
                                     "He carried it for years. Folded, pressed, like a letter never sent",
                                     "It wasn't a crime of passion. It was a crime of memory",
                                     "In his mind, it wasn'     t murder. It was balance",
                                     "Only two shadows sat at the table. Only one stood up",
                                     "No blood, no scream. Just the sound of a porcelain cup being placed... gently"
                                    };

    WordScramble wordScramble;
    [SerializeField] private GameObject[] items;
    int wordIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wordScramble = this.gameObject.GetComponent<WordScramble>();
        if (SceneManager.GetActiveScene().name == "Lvl1")
        {
           wordIndex = UnityEngine.Random.Range(0, wordsHappy.Length);
           assignWords(wordsHappy[wordIndex], items.Length);
           wordScramble.memoryText.text = endingHappy[wordIndex];
        }

        if (SceneManager.GetActiveScene().name == "Lvl22")
        {
           wordIndex = UnityEngine.Random.Range(0, wordsSuicide.Length);
           assignWords(wordsSuicide[wordIndex], items.Length);
           wordScramble.memoryText.text = endingSuicide[wordIndex];
        }

        if (SceneManager.GetActiveScene().name == "Lvl3")
        {
           wordIndex = UnityEngine.Random.Range(0, wordsMurder.Length);
           assignWords(wordsMurder[wordIndex], items.Length);
           wordScramble.memoryText.text = endingMurder[wordIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void reshuffle(GameObject[] obj)
    {
        for (int t = 0; t < obj.Length; t++)
        {
            GameObject tmp = obj[t];
            int r = UnityEngine.Random.Range(t, obj.Length);
            obj[t] = obj[r];
            obj[r] = tmp;
        }
    }

    public void assignWords(string word, int nrParts)
    {
        reshuffle(items);
        wordScramble.nrParts = nrParts;
        int nrLetters = word.Length;
        int m = nrLetters / nrParts;
        int dif = nrLetters - m * nrParts;
        int ram = 0;
        int j, i;
        //Debug.Log("nr parts" + nrParts);
        for (i = 0; i < nrParts; i++)
        {
            string newWord = "";
            for (j = 0; j < m; j++)
                newWord += word[ram + j];
            if (dif != 0)
            {
                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    dif--;
                    newWord += word[ram + j];
                    j++;
                }

            }
            if (i == nrParts - 1 && dif != 0)
            {
                while (dif != 0)
                {
                    dif--;
                    newWord += word[ram + j];
                    j++;
                }
            }
            ram += j;
            items[i].GetComponent<Letter>().index = i;
            items[i].GetComponent<Letter>().SetText(newWord);
            //wordScramble.collectedLetters[i].gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = newWord;
            //Debug.Log(newWord);
            //Debug.Log(items[i].GetComponent<Letter>().GetText());
            wordScramble.collectedLetters[i].gameObject.SetActive(true);
            wordScramble.letterHoldersGO[i].gameObject.SetActive(true);
        }

        for (; i < 5; i++)
        {
            //Debug.Log("a");
            wordScramble.collectedLetters[i].gameObject.SetActive(false);
            wordScramble.letterHoldersGO[i].gameObject.SetActive(false);
        }
    }
}
