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

    public Slider companion1Slider;
    public Slider companion2Slider;
    public Slider companion3Slider;
    public Slider companion4Slider;
    public Slider carSlider;

    void Start()
    {
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
        if(character == "car")
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
            }

            //call
            ColorHealthCheck(carSlider);
        }
        else if(character == "comp1")
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
            }

            //call
            ColorHealthCheck(companion1Slider);
        }
        else if(character == "comp2")
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
            }

            //call
            ColorHealthCheck(companion2Slider);
        }
        else if(character == "comp3")
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
            }

            //call
            ColorHealthCheck(companion3Slider);
        }
        else if(character == "comp4")
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
