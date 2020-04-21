/*
    * Author: Jacob Cohen
    * Script: RunnerStatus.cs
    * Assignment: Final Project
    * Description: Controls Runner display
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerStatus : MonoBehaviour, IObserver
{
    public HealthStatus healthStatus;
    public Text runnerText;
    public Text runsLeftText;

    // Start is called before the first frame update
    private void Start()
    {
        healthStatus.RegisterObserver(this);
    }

    public void UpdateData(List<Companion> companions)
    {
        //runs left
        runsLeftText.text = Stats.RunsLeft.ToString();

        //update active runner
        switch (Stats.ActiveRunner)
        {
            case 1:
                runnerText.text = Stats.Companion1Name;
                break;
            case 2:
                runnerText.text = Stats.Companion2Name;
                break;
            case 3:
                runnerText.text = Stats.Companion3Name;
                break;
            case 4:
                runnerText.text = Stats.Companion4Name;
                break;
            default:
                    runnerText.text = "Unselected";
                break;
        }
    }
}
