/*
    * Author: Jacob Cohen
    * Script: TutSafehouseManager.cs
    * Assignment: Final Project
    * Description: Controls the safehouse tutorial level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutSafehouseManager : MonoBehaviour
{   
    //variable
    public GameObject prompt1;
    public GameObject prompt2;
    public GameObject prompt3;
    public GameObject prompt4;
    public GameObject prompt5;
    public GameObject prompt6;
    public GameObject prompt7;
    public GameObject prompt8;
    public GameObject prompt9;
    public GameObject prompt10;
    public GameObject prompt11;
    public GameObject prompt12;
    public GameObject prompt13;
    public GameObject prompt14;
    public GameObject prompt15;
    public GameObject prompt16;
    public GameObject prompt17;
    public GameObject prompt18;
    public GameObject prompt19;
    public LevelLoader loader;
    private int currentPromptIndex;


    // Start is called before the first frame update
    void Start()
    {
        //set
        currentPromptIndex = 1;

        //turn everything off
        prompt1.SetActive(false);
        prompt2.SetActive(false);
        prompt3.SetActive(false);
        prompt4.SetActive(false);
        prompt5.SetActive(false);
        prompt6.SetActive(false);
        prompt7.SetActive(false);
        prompt8.SetActive(false);
        prompt9.SetActive(false);
        prompt10.SetActive(false);
        prompt11.SetActive(false);
        prompt12.SetActive(false);
        prompt13.SetActive(false);
        prompt14.SetActive(false);
        prompt15.SetActive(false);
        prompt16.SetActive(false);
        prompt17.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentPromptIndex)
        {
            case 1:
                //active
                prompt1.SetActive(true);
                break;
            case 2:
                //disable
                prompt1.SetActive(false);

                //active
                prompt2.SetActive(true);
                break;
            case 3:
                //disable
                prompt2.SetActive(false);

                //active
                prompt3.SetActive(true);
                break;
            case 4:
                //disable
                prompt3.SetActive(false);

                //active
                prompt4.SetActive(true);
                break;
            case 5:
                //disable
                prompt4.SetActive(false);

                //active
                prompt5.SetActive(true);
                break;
            case 6:
                //disable
                prompt5.SetActive(false);

                //active
                prompt6.SetActive(true);
                break;
            case 7:
                //disable
                prompt6.SetActive(false);

                //active
                prompt7.SetActive(true);
                break;
            case 8:
                //disable
                prompt7.SetActive(false);

                //active
                prompt8.SetActive(true);
                break;
            case 9:
                //disable
                prompt8.SetActive(false);

                //active
                prompt9.SetActive(true);
                break;
            case 10:
                //disable
                prompt9.SetActive(false);

                //active
                prompt10.SetActive(true);
                break;
            case 11:
                //disable
                prompt10.SetActive(false);

                //active
                prompt11.SetActive(true);
                break;
            case 12:
                //disable
                prompt11.SetActive(false);

                //active
                prompt12.SetActive(true);
                break;
            case 13:
                //disable
                prompt12.SetActive(false);

                //active
                prompt13.SetActive(true);
                break;
            case 14:
                //disable
                prompt13.SetActive(false);

                //active
                prompt14.SetActive(true);
                break;
            case 15:
                //disable
                prompt14.SetActive(false);

                //active
                prompt15.SetActive(true);
                break;
            case 16:
                //disable
                prompt15.SetActive(false);

                //active
                prompt16.SetActive(true);
                break;
            case 17:
                //disable
                prompt16.SetActive(false);

                //active
                prompt17.SetActive(true);
                break;
            case 18:
                //disable
                prompt17.SetActive(false);

                //active
                prompt18.SetActive(true);
                break;
            case 19:
                //disable
                prompt18.SetActive(false);

                //active
                prompt19.SetActive(true);
                break;
            case 20:
                //load next tut level
                loader.StartCoroutine("FadeToBlack", "TutGameworld");
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    public void NextPrompt()
    {
        currentPromptIndex++;
    }

    public void SkipTutorial()
    {
        //skip tuts
        loader.StartCoroutine("FadeToBlack", "Safehouse");
    }
}
