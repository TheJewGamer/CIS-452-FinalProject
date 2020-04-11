using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCompanionOneStatus : MonoBehaviour, IObserver
{
    public Companion companion;
    public HealthStatus healthStatus;

    private string statusToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        this.statusToDisplay = GetComponent<Text>().text;

        healthStatus.RegisterObserver(this);

    }

    public void UpdateData(List<Companion> companions)
    {
        this.statusToDisplay = "";

        if (companion.companion1)
        {
            this.statusToDisplay = "Companion 1 Status: " + companion.statusMessage; //companion.statusMessage;
        }
        gameObject.GetComponent<Text>().text = this.statusToDisplay;
    }
}
