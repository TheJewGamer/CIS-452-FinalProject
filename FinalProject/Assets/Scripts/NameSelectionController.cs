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
    public GameObject promptText;
    public GameObject comp1Box;
    public GameObject comp2Box;
    public GameObject comp3Box;
    public GameObject comp4Box;
    public GameObject carBox;

    private void Start() 
    {
        //hide prompts
        promptText.SetActive(false);
        comp1Box.SetActive(false);
        comp2Box.SetActive(false);
        comp3Box.SetActive(false);
        comp4Box.SetActive(false);
        carBox.SetActive(false);    
    }

    public void Companion1Set()
    {
        Stats.Companion1Name = companion1Text.text;
    }

    public void Companion1Edited()
    {
        comp1Box.SetActive(false);
        HidePrompt();
    }

    public void Companion2Set()
    {
        Stats.Companion2Name = companion2Text.text;
    }

    public void Companion2Edited()
    {
        comp2Box.SetActive(false);
        HidePrompt();
    }

    public void Companion3Set()
    {
        Stats.Companion3Name = companion3Text.text;
    }

    public void Companion3Edited()
    {
        comp3Box.SetActive(false);
        HidePrompt();
    }

    public void Companion4Set()
    {
        Stats.Companion4Name = companion4Text.text;
    }

    public void Companion4Edited()
    {
        comp4Box.SetActive(false);
        HidePrompt();
    }

    public void CarSet()
    {
        Stats.CarName = carText.text;
    }

    public void CarEdited()
    {
        carBox.SetActive(false);
        HidePrompt();
    }


    public void ConfirmPush()
    {
        //check
        if(companion1Text.text != "" && companion2Text.text != "" && companion3Text.text != "" && companion4Text.text != "" && carText.text != "")
        {
            //load overworld
            loader.StartCoroutine("FadeToBlack", "TutSafehouse");
        }
        else
        {
            //main prompt
            promptText.SetActive(true);

            //check names
            if(Stats.Companion1Name == "")
            {
                comp1Box.SetActive(true);
            }

            if(Stats.Companion2Name == "")
            {
                comp2Box.SetActive(true);
            }

            if(Stats.Companion3Name == "")
            {
                comp3Box.SetActive(true);
            }

            if(Stats.Companion4Name == "")
            {
                comp4Box.SetActive(true);
            }

            if(Stats.CarName == "")
            {
                carBox.SetActive(true);
            }
        }
    }

    private void HidePrompt()
    {
        //check to see if everything is named
        if(companion1Text.text != "" && companion2Text.text != "" && companion3Text.text != "" && companion4Text.text != "" && carText.text != "")
        {
            promptText.SetActive(false);
        }
    }
}
