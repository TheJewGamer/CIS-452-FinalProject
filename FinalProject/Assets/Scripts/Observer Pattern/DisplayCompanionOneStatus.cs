using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCompanionOneStatus : MonoBehaviour, IObserver
{
    public Companion companion;
    public HealthStatus healthStatus;
    private string statusToDisplay;
    public Text companionName;
    public Slider healthbar;
    public Text ammoCount;

    // Start is called before the first frame update
    void Start()
    {
        this.statusToDisplay = GetComponent<Text>().text;
        healthStatus.RegisterObserver(this);
    }

    public void UpdateData(List<Companion> companions)
    {
        //update status message
        this.statusToDisplay = "";
        if (companion.companion1)
        {
            this.statusToDisplay = "Companion 1 Status: " + companion.statusMessage; //companion.statusMessage;
            this.companionName.text = companion.companionName;
        }
        gameObject.GetComponent<Text>().text = this.statusToDisplay;

        //update healthbar
        healthbar.value = Stats.Companion1Health;

        //color
        healthStatus.ColorHealthCheck(healthbar);

        //ammo
        ammoCount.text = Stats.Companion1Ammo.ToString();
    }

    public void Comp1AddAmmo()
    {
        healthStatus.AmmoAdded(companion);
    }

    public void Comp1SubtractAmmo()
    {
        healthStatus.AmmoSubtracted(companion);
    }

    public void Comp1Heal()
    {
        healthStatus.Healed(companion);
    }

    public void Comp1Runner()
    {
        healthStatus.SetRunner(companion);
    }
}
