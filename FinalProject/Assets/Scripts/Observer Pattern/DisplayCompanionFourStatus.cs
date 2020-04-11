using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCompanionFourStatus : MonoBehaviour, IObserver
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

        if (companion.companion4)
        {
            this.statusToDisplay = "Companion 4 Status: " + companion.statusMessage; //companion.statusMessage;
        }
        gameObject.GetComponent<Text>().text = this.statusToDisplay;
    }
}
