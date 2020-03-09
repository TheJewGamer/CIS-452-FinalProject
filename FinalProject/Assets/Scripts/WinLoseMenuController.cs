﻿/*
    * Jacob Cohen
    * WinLoseMenuController.cs
    * Assignment #7
    * controls the win and lose menu
*/


using System.Collections;
using System.Collections.Generic;
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
