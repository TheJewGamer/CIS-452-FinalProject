/*
    * Jacob Cohen
    * MainMenuController.cs
    * Final Project
    * controls the main menu
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;

    // Start is called before the first frame update
    private void Start()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void StartPushed()
    {
        SceneManager.LoadScene("NameSelection");
    }

    public void CreditsPushed()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void BackPushed()
    {
        creditsMenu .SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitPushed()
    {
        Application.Quit();
        Debug.Log("Quit only works on build");
    }
}
