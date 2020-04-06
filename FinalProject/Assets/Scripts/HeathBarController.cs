using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBarController : MonoBehaviour
{
    //variables
    private Slider healthBar;
    private float maxValue = 10f;

    // Start is called before the first frame update
    private void Start()
    {
        //set bar to max value
        healthBar = gameObject.GetComponent<Slider>();
        healthBar.maxValue = maxValue;
        healthBar.value = maxValue;

        //sets the color to green
        ColorBlock cb = healthBar.colors;
        cb.normalColor = Color.green;
        healthBar.colors = cb;
    }

    public void Attacked()
    {
        //update
        healthBar.value--;

        //call
        ColorCheck();
    }

    private void ColorCheck()
    {
        if(healthBar.value > 7)
        {
            //set color to green
            ColorBlock cb = healthBar.colors;
            cb.normalColor = Color.green;
            healthBar.colors = cb;
        }
        else if(healthBar.value < 7 && healthBar.value > 3)
        {
            //set color to yellow
            ColorBlock cb = healthBar.colors;
            cb.normalColor = Color.yellow;
            healthBar.colors = cb;
        }
        else
        {
            //set color to red
            ColorBlock cb = healthBar.colors;
            cb.normalColor = Color.red;
            healthBar.colors = cb;
        }
    }

}
