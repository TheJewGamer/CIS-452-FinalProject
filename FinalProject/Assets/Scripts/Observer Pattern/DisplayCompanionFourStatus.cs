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
    public Text ammoCount;

    // Start is called before the first frame update
    void Start()
    {
        this.statusToDisplay = GetComponent<Text>().text;

        healthStatus.RegisterObserver(this);

    }

    public void UpdateData(List<Companion> companions)
    {
        this.statusToDisplay = "";

        if (companion.companion4)
        {
            this.statusToDisplay = "Companion 4 Status: " + companion.statusMessage; //companion.statusMessage;
        }
        gameObject.GetComponent<Text>().text = this.statusToDisplay;

        //update healthbar
        healthbar.value = Stats.Companion4Health;

        //color
        healthStatus.ColorHealthCheck(healthbar);

        //ammo
        ammoCount.text = Stats.Companion4Ammo.ToString();
    }

    public void Comp4AddAmmo()
    {
        healthStatus.AmmoAdded(companion);
    }

    public void Comp4SubtractAmmo()
    {
        healthStatus.AmmoSubtracted(companion);
    }

    public void Comp4Heal()
    {
        healthStatus.Healed(companion);
    }

    public void Comp4Runner()
    {
        healthStatus.SetRunner(companion);
    }
}
