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

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
    }

    public void StartPushed()
    {
        SceneManager.LoadScene("NameSelection");
    }

    public void QuitPushed()
    {
        Application.Quit();
        Debug.Log("Quit only works on build");
    }
}
