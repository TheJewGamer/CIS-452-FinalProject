using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCompanionThreeStatus : MonoBehaviour, IObserver
{
    public Companion companion;
    public HealthStatus healthStatus;
    private string statusToDisplay;
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
        this.statusToDisplay = "";

        if (companion.companion3)
        {
            this.statusToDisplay = "Companion 3 Status: " + companion.statusMessage; //companion.statusMessage;
        }
        gameObject.GetComponent<Text>().text = this.statusToDisplay;

        //update healthbar
        healthbar.value = Stats.Companion3Health;

        //color
        healthStatus.ColorHealthCheck(healthbar);

        //ammo
        ammoCount.text = Stats.Companion3Ammo.ToString();
    }

    public void Comp3AddAmmo()
    {
        healthStatus.AmmoAdded(companion);
    }

    public void Comp3SubtractAmmo()
    {
        healthStatus.AmmoSubtracted(companion);
    }

    public void Comp3Heal()
    {
        healthStatus.Healed(companion);
    }

    public void Comp3Runner()
    {
        healthStatus.SetRunner(companion);
    }
}
