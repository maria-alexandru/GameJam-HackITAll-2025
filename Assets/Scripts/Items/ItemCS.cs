using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class ItemCS : MonoBehaviour
{   
    private bool inRange;
    public string message;
    public GameObject ItemSelectedMsj;
    public WordScramble wordScramble;
    public bool isSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSelected = false;
        wordScramble = GameObject.FindGameObjectWithTag("WordScramble").GetComponent<WordScramble>();
        ItemSelectedMsj.SetActive(false);
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(inRange) 
            {
                Vector2 mousePos = GameObject.Find("Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null) 
                {
                    // Debug.Log("!" + hit.collider.tag);
                    if (hit.transform.tag == "Panel")
                    {
                        wordScramble.OpenPanel();
                    }
                    else if (hit.transform.tag == "Item")
                    {
                        //Debug.Log("hit: " + hit.collider.gameObject.name);
                        InteractionManager.getList().Add(this.gameObject);

                        ItemSelectedMsj.SetActive(true);
                        StartCoroutine(ApplyFunctionWithDelay());
                    }
                }
            }
        }
    }

    IEnumerator ApplyFunctionWithDelay() 
    {
        yield return new WaitForSeconds(0.5f);

        ItemSelectedMsj.SetActive(false);
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
        isSelected = true;

    }

    public void isInRange() {
        inRange = true;
    }

    public void isOutOfRange() {
        inRange = false;
    }
}
