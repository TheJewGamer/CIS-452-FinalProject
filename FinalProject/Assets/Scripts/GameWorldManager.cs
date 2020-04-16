using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldManager : MonoBehaviour
{
    //variables
    public GameObject comp1;
    public GameObject comp2;
    public GameObject comp3;
    public GameObject comp4;
    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        //turn off all players
        comp1.SetActive(false);
        comp2.SetActive(false);
        comp3.SetActive(false);
        comp4.SetActive(false);

        //get player to activate
        switch(Stats.ActiveRunner)
        {
            case 1:
                comp1.SetActive(true);
                controller = comp1.GetComponent<PlayerController>();
                break;
                
            case 2:
                comp2.SetActive(true);
                controller = comp1.GetComponent<PlayerController>();
                break;
                
            case 3:
                comp3.SetActive(true);
                controller = comp1.GetComponent<PlayerController>();
                break;
                
            case 4:
                comp4.SetActive(true);
                controller = comp1.GetComponent<PlayerController>();
                break;

            default:
                //testing
                comp1.SetActive(true);
                controller = comp1.GetComponent<PlayerController>();
                break;

        }
    }


    //button stuff
    public void MedicalDropButton()
    {
        controller.MedicalDrop();
    }

    public void FuelDropButton()
    {
        controller.FuelDrop();
    }

    public void AmmoDropButton()
    {
        controller.AmmoDrop();
    }
}
