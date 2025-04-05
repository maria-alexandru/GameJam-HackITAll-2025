using System;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public Sprite sprite;
    public int index;
    public WordScramble wordScramble;
    public string text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = "";
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
}
