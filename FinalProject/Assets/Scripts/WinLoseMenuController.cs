/*
    * Jacob Cohen
    * WinLoseMenuController.cs
    * Final Project
    * controls the win and lose menu
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseMenuController : MonoBehaviour
{
    //variables
    public LevelLoader loader;
    public Text compCount;

    private void OnEnable() 
    {
        //var
        int alive = 0;

        //get who is alive
        if(Stats.Companion1Dead == false)
        {
            alive++;
        }    
        if(Stats.Companion2Dead == false)
        {
            alive++;
        }
        if(Stats.Companion3Dead == false)
        {
            alive++;
        }
        if(Stats.Companion4Dead == false)
        {
            alive++;
        }

        //update text
        compCount.text = alive.ToString();
    }

    public void RetryPushed()
    {
        loader.StartCoroutine("FadeToBlack", "SafeHouse");
    }

    public void MainMenuPushed()
    {
        loader.StartCoroutine("FadeToBlack", "Menu");
    }
}
