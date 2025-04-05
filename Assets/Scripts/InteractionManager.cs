using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractionManager : MonoBehaviour
{
    public static List<GameObject> selectedItems;
    public GameObject tips;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tips = GameObject.Find("Tips Message");
        tips.SetActive(false);

        selectedItems = new List<GameObject>();
    }

    // este in range si marchez
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("" + other.gameObject.name);
        if(other.CompareTag("Item")) {
            GameObject item = other.gameObject;
            ItemCS script = item.GetComponent<ItemCS>();
            script.isInRange();
            tips.SetActive(true);
        }
    }

    // nu mai este in range
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Item")) {
            GameObject item = other.gameObject;
            ItemCS script = item.GetComponent<ItemCS>();
            tips.SetActive(false);
            script.isOutOfRange();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static List<GameObject> getList() {
        return selectedItems;
    }
}
