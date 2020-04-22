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

    private bool promp1Done;
    private bool prompt1Done;
    private bool prompt2Done;
    private bool prompt3Done;
    private bool prompt4Done;
    private bool prompt5Done;
    private bool prompt6Done;
    private bool prompt7Done;
    private bool prompt8Done;
    private bool prompt9Done;
    private bool prompt10Done;
    private bool prompt11Done;
    private bool prompt12Done;
    private bool prompt13Done;
    private bool prompt14Done;
    private bool prompt15Done;
    private bool prompt16Done;
    private bool prompt17Done;
    private bool prompt18Done;

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
        prompt18.SetActive(false);

        //false
        promp1Done = false;
        prompt1Done = false;
        prompt2Done = false;
        prompt3Done = false;
        prompt4Done = false;
        prompt5Done = false;
        prompt6Done = false;
        prompt7Done = false;
        prompt8Done = false;
        prompt9Done = false;
        prompt10Done = false;
        prompt11Done = false;
        prompt12Done = false;
        prompt13Done = false;
        prompt14Done = false;
        prompt15Done = false;
        prompt16Done = false;
        prompt17Done = false;
        prompt18Done = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentPromptIndex)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
                break;
            case 16:
                break;
            case 17:
                break;
            case 18:
                break;
            default:
                Debug.Log("Error");
                break;
        }

        //prompt1
        
            //active
            prompt1.SetActive(true);
        //prompt2
        if(prompt2)
        {
            //active
            prompt2.SetActive(true);
        }
        //prompt3
        else if(prompt3)
        {
            //active
            prompt3.SetActive(true);
        }
        //prompt4
        else if(prompt4)
        {
            //active
            prompt4.SetActive(true);
        }
        //prompt5
        else if(prompt5)
        {
            //active
            prompt5.SetActive(true);
        }
        //prompt6
        else if(prompt6)
        {
            //active
            prompt6.SetActive(true);
        }
        //prompt7
        else if(prompt7)
        {
            //active
            prompt7.SetActive(true);
        }
        //prompt8
        else if(prompt8)
        {
            //active
            prompt8.SetActive(true);
        }
        //prompt9
        else if(prompt9)
        {
            //active
            prompt9.SetActive(true);
        }
        //prompt10
        else if(prompt10)
        {
            //active
            prompt10.SetActive(true);
        }
        //prompt11
        else if(prompt11)
        {
            //active
            prompt11.SetActive(true);
        }
        //prompt12
        else if(prompt12)
        {
            //active
            prompt12.SetActive(true);
        }
        //prompt13
        else if(prompt13)
        {
            //active
            prompt13.SetActive(true);
        }
        //prompt14
        else if(prompt14)
        {
            //active
            prompt14.SetActive(true);
        }
        //prompt15
        else if(prompt15)
        {
            //active
            prompt15.SetActive(true);
        }
        //prompt16
        else if(prompt16)
        {
            //active
            prompt16.SetActive(true);
        }
        //prompt17
        else if(prompt17)
        {
            //active
            prompt17.SetActive(true);
        }
        //prompt18
        else if(prompt18)
        {
            //active
            prompt18.SetActive(true);
        }
    }
}
