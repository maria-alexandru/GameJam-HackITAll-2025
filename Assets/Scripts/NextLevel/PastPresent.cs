using UnityEngine;
using UnityEngine.UI;

public class PastPresent : MonoBehaviour
{
    [SerializeField] private Sprite[] pastSprites;
    [SerializeField] private Sprite[] presentSprites;
    [SerializeField] private Sprite pastWall;
    [SerializeField] private Sprite presentWall;
    [SerializeField] private GameObject[] backgroundImages;
    [SerializeField] private GameObject[] wallsImages;
    [SerializeField] private PuzzleManager puzzleManager;
    [SerializeField] private Texture2D puzzleImage;
    [SerializeField] private int opt;
    // 9C9C9C - culoare trecut perete
    // 7E7E7E - culoare present perete

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        opt = 0;
        PastToPresent();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (opt == 0)
            {
                opt = 1;
                PresentToPast();
            }
            else
            {
                opt = 0;
                PastToPresent();
            }
        }
    }

    public void PastToPresent()
    {
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            backgroundImages[i].GetComponent<SpriteRenderer>().sprite = presentSprites[i];
        }
        for (int i = 0; i < wallsImages.Length; i++)
        {
            wallsImages[i].GetComponent<SpriteRenderer>().sprite = presentWall;
        }
    }

    public void PresentToPast()
    {
        //puzzleManager.StartGame(puzzleImage);
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            backgroundImages[i].GetComponent<SpriteRenderer>().sprite = pastSprites[i];
        }
        for (int i = 0; i < wallsImages.Length; i++)
        {
            wallsImages[i].GetComponent<SpriteRenderer>().sprite = pastWall;
        }
    }
}
