/*
    * Author: CJ Green, Jacob Cohen
    * Script: DisplayCompanionFourStatus.cs
    * Assignment: Final Project
    * Description: Controls companion 4 stats display
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCompanionFourStatus : MonoBehaviour, IObserver
{
    public Companion companion;
    public HealthStatus healthStatus;
    public Slider healthbar;
    private string statusToDisplay;
    public Text companionName;
    public Text ammoCount;
    public GameObject[] objectsToHide;

    public SafeHouseAudioManager safeHouseAudioManager;

    // Start is called before the first frame update
    private void Start()
    {
        this.statusToDisplay = GetComponent<Text>().text;
        healthStatus.RegisterObserver(this);
        healthbar.value = Stats.Companion4Health;

        safeHouseAudioManager = GameObject.Find("Scripts").GetComponent<SafeHouseAudioManager>();
    }

    public void UpdateData(List<Companion> companions)
    {
        this.statusToDisplay = "";

        if (companion.companion4)
        {
            this.statusToDisplay = companion.companionName + " Status: " + companion.statusMessage; //companion.statusMessage;
            this.companionName.text = companion.companionName;

        }
        gameObject.GetComponent<Text>().text = this.statusToDisplay;

        //update healthbar
        healthbar.value = Stats.Companion4Health;

        //color
        healthStatus.ColorHealthCheck(healthbar);

        //ammo
        ammoCount.text = Stats.Companion4Ammo.ToString();

        //check if dead
        if(Stats.Companion4Health == 0)
        {
            //hide buttons and ammo
            foreach(GameObject item in objectsToHide)
            {
                item.SetActive(false);
            }
        }
    }

    public void Comp4AddAmmo()
    {
        healthStatus.AmmoAdded(companion);

        if(Stats.AmmoSuppliesCount > 0)
        {
            safeHouseAudioManager.PlayPlusButton();
        }

    }

    public void Comp4SubtractAmmo()
    {
        healthStatus.AmmoSubtracted(companion);

        if (Stats.Companion2Ammo > 0)
        {
            safeHouseAudioManager.PlayMinusButton();
        }
    }

    public void Comp4Heal()
    {
        healthStatus.Healed(companion);

        if(Stats.MedicalSuppliesCount > 0 && Stats.Companion4Health < Stats.MaxHealth)
        {
            safeHouseAudioManager.PlayPlusButton();
        }

    }

    public void Comp4Runner()
    {
        healthStatus.SetRunner(companion);
    }
}
