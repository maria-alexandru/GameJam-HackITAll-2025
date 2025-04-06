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
    [SerializeField] private Sprite pastImg, presentImg;
    [SerializeField] private GameObject button;
    private GameObject[] items;
    private const int possibilities = 3;
    private int index;

    // 9C9C9C - culoare trecut perete
    // 7E7E7E - culoare present perete

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initItemsData();

        opt = 0;
        PastToPresent();

    }

    void initItemsData() 
    {
        items = GameObject.FindGameObjectsWithTag("Item");
        index = Random.Range(0, possibilities);
        //Debug.Log(index);
        foreach(GameObject obj in items)
        {
            ObjectData data = obj.GetComponent<ObjectData>();
            obj.transform.position = data.positions[index];

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ChooseButton();
        }
    }

    public void ChooseButton() {
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

    public void PastToPresent()
    {
        button.GetComponent<Image>().sprite = pastImg;
        for(int i = 0; i < items.Length; i++) {
            ItemCS data = items[i].GetComponent<ItemCS>();

            if(data.isSelected == false)
                if (items[i].layer == 6) {
                    items[i].SetActive(true);
                } else if(items[i].layer == 7) {
                    items[i].SetActive(false);
                }
        }

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
        button.GetComponent<Image>().sprite = presentImg;

        for(int i = 0; i < items.Length; i++) {
            ItemCS data = items[i].GetComponent<ItemCS>();

            if(data.isSelected == false)
                if (items[i].layer == 6) {
                    items[i].SetActive(false);
                } else if(items[i].layer == 7) {
                    items[i].SetActive(true);
                }
        }

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
