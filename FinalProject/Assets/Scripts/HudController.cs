using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    //variables
    public Text companion1Text;
    public Text companion2Text;
    public Text companion3Text;
    public Text companion4Text;
    public Text carText;

    private Slider companion1Slider;
    private Slider companion2Slider;
    private Slider companion3Slider;
    private Slider companion4Slider;
    private Slider carSlider;

    void Start()
    {
        //get componets
        companion1Slider = companion1Text.gameObject.GetComponentInChildren<Slider>();
        companion2Slider = companion2Text.gameObject.GetComponentInChildren<Slider>();
        companion3Slider = companion3Text.gameObject.GetComponentInChildren<Slider>();
        companion4Slider = companion4Text.gameObject.GetComponentInChildren<Slider>();
        carSlider = carText.gameObject.GetComponentInChildren<Slider>();

        //set names
        companion1Text.text = Stats.Companion1Name;
        companion2Text.text = Stats.Companion2Name;
        companion3Text.text = Stats.Companion3Name;
        companion4Text.text = Stats.Companion4Name;
        carText.text = Stats.CarName;

        //set health
        companion1Slider.value = Stats.Companion1Health;
        companion2Slider.value = Stats.Companion2Health;
        companion3Slider.value = Stats.Companion3Health;
        companion4Slider.value = Stats.Companion4Health;
        carSlider.value = Stats.CarHealth;
    }

    public void updateHealth(string character, bool healing)
    {
        if(character == "car" && !Stats.CarDestroyed)
        {
            //check to see if to add or remove health
            if(healing)
            {
                carSlider.value++;
                Stats.CarHealth = carSlider.value;
            }
            else
            {
                carSlider.value--;
                Stats.CarHealth = carSlider.value;

                //check to see if dead
                if(Stats.CarHealth == 0)
                {
                    Stats.CarDestroyed = true;
                }
            }

            //call
            ColorHealthCheck(carSlider);
        }
        else if(character == "comp1" && !Stats.Companion1Dead)
        { 
            //check to see if to add or remove health
            if(healing)
            {
                companion1Slider.value++;
                Stats.Companion1Health = companion1Slider.value;
            }
            else
            {
                companion1Slider.value--;
                Stats.Companion1Health = companion1Slider.value;

                //check to see if dead
                if(Stats.Companion1Health == 0)
                {
                    Stats.Companion1Dead = true;
                }
            }

            //call
            ColorHealthCheck(companion1Slider);
        }
        else if(character == "comp2" && !Stats.Companion4Dead)
        {
            //check to see if to add or remove health
            if(healing)
            {
                companion2Slider.value++;
                Stats.Companion2Health = companion2Slider.value;
            }
            else
            {
                companion2Slider.value--;
                Stats.Companion2Health = companion2Slider.value;

                //check to see if dead
                if(Stats.Companion2Health == 0)
                {
                    Stats.Companion2Dead = true;
                }
            }

            //call
            ColorHealthCheck(companion2Slider);
        }
        else if(character == "comp3" && !Stats.Companion3Dead)
        {
            //check to see if to add or remove health
            if(healing)
            {
                companion3Slider.value++;
                Stats.Companion3Health = companion3Slider.value;
            }
            else
            {
                companion3Slider.value--;
                Stats.Companion3Health = companion3Slider.value;

                //check to see if dead
                if(Stats.Companion3Health == 0)
                {
                    Stats.Companion3Dead = true;
                }
            }

            //call
            ColorHealthCheck(companion3Slider);
        }
        else if(character == "comp4" && !Stats.Companion4Dead)
        {
            //check to see if to add or remove health
            if(healing)
            {
                companion4Slider.value++;
                Stats.Companion4Health = companion4Slider.value;
            }
            else
            {
                companion4Slider.value--;
                Stats.Companion4Health = companion4Slider.value;

                //check to see if dead
                if(Stats.Companion4Health == 0)
                {
                    Stats.Companion4Dead = true;
                }
            }

            //call
            ColorHealthCheck(companion4Slider);
        }
    }

    private void ColorHealthCheck(Slider inputSlider)
    {
        //variables
        ColorBlock cb = inputSlider.colors;

        //check to see if dead
        if(inputSlider.value <= 0)
        {
            //check to see if everyone is dead
            Dead();
        }

        //color change/confirm
        if(inputSlider.value > 7)
        {
            //set color to green
            cb.normalColor = Color.green;
            inputSlider.colors = cb;
        }
        else if(inputSlider.value < 7 && inputSlider.value > 3)
        {
            //set color to yellow
            cb.normalColor = Color.yellow;
            inputSlider.colors = cb;
        }
        else
        {
            //set color to red
            cb.normalColor = Color.red;
            inputSlider.colors = cb;
        }

    }

    private void Dead()
    {
        if(Stats.Companion1Health == 0 && Stats.Companion2Health == 0 && Stats.Companion3Health == 0 && Stats.Companion4Health == 0 && Stats.CarHealth == 0)
        {
            //game over
        }
    }
}
