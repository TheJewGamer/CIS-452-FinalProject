/*
    * Jacob Cohen
    * NameSelectionController.cs
    * Final Project
    * General controller for the name selector level/menu
*/


using UnityEngine;
using UnityEngine.UI;

public class NameSelectionController : MonoBehaviour
{
    //variables
    public Text companion1Text;
    public Text companion2Text;
    public Text companion3Text;
    public Text companion4Text;
    public Text carText;
    public LevelLoader loader;

    public void Companion1Set()
    {
        Stats.Companion1Name = companion1Text.text;
    }
    public void Companion2Set()
    {
        Stats.Companion2Name = companion2Text.text;
    }
    public void Companion3Set()
    {
        Stats.Companion3Name = companion3Text.text;
    }
    public void Companion4Set()
    {
        Stats.Companion4Name = companion4Text.text;
    }
    public void CarSet()
    {
        Stats.CarName = carText.text;
    }

    public void ConfirmPush()
    {
        //check
        if(companion1Text.text != null || companion2Text.text != null || companion3Text.text != null || companion4Text.text != null || carText.text != null)
        {
            //load overworld
            loader.StartCoroutine("FadeToBlack", "Safehouse");
        }
        else
        {
            //tell user to name things
        }
    }
}
