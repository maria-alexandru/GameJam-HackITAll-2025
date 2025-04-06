using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

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
        //Debug.Log("" + other.gameObject.name);
        if(other.CompareTag("Item") || other.CompareTag("Panel")) {
            GameObject item = other.gameObject;
            ItemCS script = item.GetComponent<ItemCS>();
            script.isInRange();
            tips.SetActive(true);

            if (other.CompareTag("Panel"))
                tips.GetComponent<TextMeshProUGUI>().text = "Click on the panel and find out the secret word";
            else
                tips.GetComponent<TextMeshProUGUI>().text = "You feel a familiar item...\r\nFind it and click it";
        }
    }

    // nu mai este in range
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Item") || other.CompareTag("Panel")) {
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
