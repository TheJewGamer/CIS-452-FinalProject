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
    void Start()
    {
        healthStatus.RegisterObserver(this);
        carName.text = Stats.CarName;
    }

    public void UpdateData(List<Companion> companions)
    {
        //update fuelbar
        fuelbar.value = Stats.Companion1Health;

        //color
        healthStatus.ColorHealthCheck(fuelbar);
    }

    public void CarAddFuel()
    {
        healthStatus.AddFuel();
    }
}
