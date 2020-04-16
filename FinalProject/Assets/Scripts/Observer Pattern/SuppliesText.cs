/*
    * Author: Jacob Cohen
    * Script: SuppliesText.cs
    * Assignment: Final Project
    * Description: Controls the supplies display
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuppliesText : MonoBehaviour, IObserver
{
    public HealthStatus healthStatus;
    public Text ammoCount;
    public Text medicalCount;
    public Text gasCount;

    // Start is called before the first frame update
    private void Start()
    {
        healthStatus.RegisterObserver(this);
    }

    public void UpdateData(List<Companion> companions)
    {
        ammoCount.text = Stats.AmmoSuppliesCount.ToString();
        medicalCount.text = Stats.MedicalSuppliesCount.ToString();
        gasCount.text = Stats.FuelSuppliesCount.ToString();
    }
}
