using UnityEngine;

public class OptionsMenuManager : MonoBehaviour
{
    public GameObject backgroundMenu;
    public GameObject optionsPanel;

    public void BackToMainMenu()
    {
        optionsPanel.SetActive(false);
        backgroundMenu.SetActive(true);
    }
}
