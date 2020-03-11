/*
    * Jacob Cohen
    * WinLoseMenuController.cs
    * Final Project
    * controls the win and lose menu
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseMenuController : MonoBehaviour
{
    public void RetryPushed()
    {
        Time.timeScale = 0;

        SceneManager.LoadScene("Game");
    }

    public void MainMenuPushed()
    {
        SceneManager.LoadScene("Menu");
    }
}
