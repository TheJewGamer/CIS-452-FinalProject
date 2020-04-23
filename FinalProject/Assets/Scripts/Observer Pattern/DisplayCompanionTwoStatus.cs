/*
    * Author: CJ Green, Jacob Cohen
    * Script: DisplayCompanionTwoStatus.cs
    * Assignment: Final Project
    * Description: Controls companion 2 stats display
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCompanionTwoStatus : MonoBehaviour, IObserver
{
    public Companion companion;
    public HealthStatus healthStatus;
    private string statusToDisplay;
    public Slider healthbar;
    public Text companionName;
    public Text ammoCount;
    public GameObject[] objectsToHide;

    // Start is called before the first frame update
    private void Start()
    {
        this.statusToDisplay = GetComponent<Text>().text;

        healthStatus.RegisterObserver(this);
    }

    public void UpdateData(List<Companion> companions)
    {
        this.statusToDisplay = "";

        if (companion.companion2)
        {
            this.statusToDisplay = companion.companionName + " Status: " + companion.statusMessage; //companion.statusMessage;
            this.companionName.text = companion.companionName;
        }
        gameObject.GetComponent<Text>().text = this.statusToDisplay;

        //update healthbar
        healthbar.value = Stats.Companion2Health;

        //color
        healthStatus.ColorHealthCheck(healthbar);

        //ammo
        ammoCount.text = Stats.Companion2Ammo.ToString();

        //check if dead
        if(Stats.Companion2Health == 0)
        {
            //hide buttons and ammo
            foreach(GameObject item in objectsToHide)
            {
                item.SetActive(false);
            }
        }
    }

    public void Comp2AddAmmo()
    {
        healthStatus.AmmoAdded(companion);
    }

    public void Comp2SubtractAmmo()
    {
        healthStatus.AmmoSubtracted(companion);
    }

    public void Comp2Heal()
    {
        healthStatus.Healed(companion);
    }

    public void Comp2Runner()
    {
        healthStatus.SetRunner(companion);
    }
}
