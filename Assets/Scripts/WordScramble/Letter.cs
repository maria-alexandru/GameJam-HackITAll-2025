using System;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public int index;
    public WordScramble wordScramble;
    [SerializeField] private string text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wordScramble = GameObject.FindGameObjectWithTag("WordScramble").GetComponent<WordScramble>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        wordScramble.PlaceLetter(this);
    }

    public void SetText(string text)
    {
        this.text = text;
    }

    public string GetText()
    {
        return text;
    }
}
