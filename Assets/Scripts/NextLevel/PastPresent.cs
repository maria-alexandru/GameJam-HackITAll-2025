using UnityEngine;
using UnityEngine.UI;

public class PastPresent : MonoBehaviour
{
    [SerializeField] private Sprite[] pastSprites;
    [SerializeField] private Sprite[] presentSprites;
    [SerializeField] private GameObject[] backgroundImages;
    [SerializeField] private PuzzleManager puzzleManager;
    [SerializeField] private Texture2D puzzleImage;
    [SerializeField] private int opt;
    // 9C9C9C - culoare trecut perete
    // 7E7E7E - culoare present perete

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        opt = -1;

    }

    // Update is called once per frame
    void Update()
    {
        if (opt == 0)
            PastToPresent();
        else if (opt == 1)
            PresentToPast();
    }

    public void PastToPresent()
    {
        opt = -1;
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            backgroundImages[i].GetComponent<SpriteRenderer>().sprite = presentSprites[i];
        }
    }

    public void PresentToPast()
    {
        opt = -1;
        puzzleManager.StartGame(puzzleImage);
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            backgroundImages[i].GetComponent<SpriteRenderer>().sprite = pastSprites[i];
        }
    }
}
