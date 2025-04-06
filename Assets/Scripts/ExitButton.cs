using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Iesire din joc...");
        Application.Quit();
    }
}
