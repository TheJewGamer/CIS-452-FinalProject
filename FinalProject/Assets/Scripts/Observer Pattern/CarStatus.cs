/*
    * Author: Jacob Cohen
    * Script: IObserver.cs
    * Assignment: Final Project
    * Description: This script controls the display of car stats
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarStatus : MonoBehaviour, IObserver
{
    public HealthStatus healthStatus;
    public Slider fuelbar;
    public Text carName;

    // Start is called before the first frame update
    private void Start()
    {
        healthStatus.RegisterObserver(this);
        carName.text = Stats.CarName;
        fuelbar.maxValue = Stats.MaxFuel;
    }

    public void UpdateData(List<Companion> companions)
    {
        //update fuelbar
        fuelbar.value = Stats.CarFuel;

        //color
        healthStatus.ColorHealthCheck(fuelbar);
    }

    public void CarAddFuel()
    {
        healthStatus.AddFuel();
    }
}
