using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject musicPanel;
    public GameObject sfxPanel;

    private bool isVisible = false;

    public void ToggleOptions()
    {
        isVisible = !isVisible;
        musicPanel.SetActive(isVisible);
        sfxPanel.SetActive(isVisible);
    }
}
