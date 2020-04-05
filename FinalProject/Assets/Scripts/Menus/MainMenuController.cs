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
    public GameObject versionMenu;
    public GameObject tutMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        tutMenu.SetActive(false);
        versionMenu.SetActive(false);
    }

    public void StartPushed()
    {
        mainMenu.SetActive(false);
        versionMenu.SetActive(true);
    }

    public void funnyVersion()
    {
        //set something maybe

        //menus
        versionMenu.SetActive(false);
        tutMenu.SetActive(true);
    }

    public void normalVersion()
    {
        //set something maybe

        //menus
        versionMenu.SetActive(false);
        tutMenu.SetActive(true);
    }

    public void YesPushed()
    {
        SceneManager.LoadScene("Tut");
    }

    public void NoPushed()
    {
        SceneManager.LoadScene("Game");
    }


    public void BackPushed()
    {
        mainMenu.SetActive(true);
        tutMenu.SetActive(false);
    }

    public void QuitPushed()
    {
        Application.Quit();
        Debug.Log("Quit only works on build");
    }
}
