/*
    * Author: CJ Green
    * Script: Companion.cs
    * Assignment: Final Project
    * Description: This script defines the different companions and adds them to the companions list in HealthStatus
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    public bool companion1;
    public bool companion2;
    public bool companion3;
    public bool companion4;

    public float companionCurrentHealth;
    public string companionName;
    public string statusMessage;

    public HealthStatus healthStatus;

    // Start is called before the first frame update
    void Start()
    {

        healthStatus.AddCompanions(this);

        //get health
        if (companion1)
        {
            companionCurrentHealth = Stats.Companion1Health;
            companionName = Stats.Companion1Name;
        }
        else if (companion2)
        {
            companionCurrentHealth = Stats.Companion2Health;
            companionName = Stats.Companion2Name;
        }
        else if(companion3)
        {
            companionCurrentHealth = Stats.Companion3Health;
            companionName = Stats.Companion3Name;
        }
        else if(companion4)
        {
            companionCurrentHealth = Stats.Companion4Health;
            companionName = Stats.Companion4Name;
        }

        //update status message
        if (companionCurrentHealth >= 10)
        {
            statusMessage = "This survivor is doing well.";
            healthStatus.NotifyObservers();
        }
        else if (companionCurrentHealth < 10 && companionCurrentHealth > 5)
        {
            statusMessage = "This survivor is injured. They may need healing.";
            healthStatus.NotifyObservers();
        }
        else if (companionCurrentHealth < 5)
        {
            statusMessage = "This survivor is seriously injured and needs immediate medical attention";
            healthStatus.NotifyObservers();
        }
        else if (companionCurrentHealth <= 0)
        {
            statusMessage = "This survivor has died...Rest In Peace ";
            healthStatus.NotifyObservers();
        }
    }
}
