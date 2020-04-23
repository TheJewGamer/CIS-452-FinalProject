/*
    * Jacob Cohen
    * GameWorldManager.cs
    * Final Project
    * General controller for the game world
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWorldManager : MonoBehaviour
{
    //variables
    public GameObject comp1;
    public GameObject comp2;
    public GameObject comp3;
    public GameObject comp4;
    private PlayerController controller;
    public Collider2D safehouse;
    public GameObject safeHouseMenu;

    //menu stuff
    public GameObject inventoryMenu;

    public GameObject ammoImage1;
    public GameObject ammoImage2;
    public GameObject ammoImage3;
    public GameObject ammoImage4;
    public GameObject ammoImage5;

    public GameObject healthImage1;
    public GameObject healthImage2;
    public GameObject healthImage3;
    public GameObject healthImage4;
    public GameObject healthImage5;

    public GameObject fuelImage1;
    public GameObject fuelImage2;
    public GameObject fuelImage3;
    public GameObject fuelImage4;
    public GameObject fuelImage5;
    public GameObject hitEffect;
    public Slider healthbar;

    //misc stuff
    public LevelLoader loader;
    private PlayerController activeComp;
    public AudioFacade audioManager;

    // Start is called before the first frame update
    void Start()
    {
        //turn off all players
        comp1.SetActive(false);
        comp2.SetActive(false);
        comp3.SetActive(false);
        comp4.SetActive(false);

        //turn off menu
        safeHouseMenu.SetActive(false);

        //start intro music
       // audioManager.

         //add player script to right character
        switch (Stats.ActiveRunner)
        {
            case 1:
                comp1.AddComponent<PlayerController>();
                activeComp = comp1.GetComponent<PlayerController>();
                comp1.SetActive(true);
                break;
            case 2:
                comp2.AddComponent<PlayerController>();
                activeComp = comp2.GetComponent<PlayerController>();
                comp2.SetActive(true);
                break;
            case 3:
                comp3.AddComponent<PlayerController>();
                activeComp = comp3.GetComponent<PlayerController>();
                comp3.SetActive(true);
                break;
            case 4:
                comp4.AddComponent<PlayerController>();
                activeComp = comp4.GetComponent<PlayerController>();
                comp4.SetActive(true);
                break;
            default:
                comp1.AddComponent<PlayerController>();
                activeComp = comp1.GetComponent<PlayerController>();
                comp1.SetActive(true);
                break;
        }

        //update player vars
        activeComp.inventoryMenu = this.inventoryMenu;
        activeComp.safeHouseMenu = this.safeHouseMenu;
        activeComp.ammoImage1 = this.ammoImage1;
        activeComp.ammoImage2 = this.ammoImage2;
        activeComp.ammoImage3 = this.ammoImage3;
        activeComp.ammoImage4 = this.ammoImage4;
        activeComp.ammoImage5 = this.ammoImage5;
        activeComp.healthImage1 = this.healthImage1;
        activeComp.healthImage2 = this.healthImage2;
        activeComp.healthImage3 = this.healthImage3;
        activeComp.healthImage4 = this.healthImage4;
        activeComp.healthImage5 = this.healthImage5;
        activeComp.fuelImage1 = this.fuelImage1;
        activeComp.fuelImage2 = this.fuelImage2;
        activeComp.fuelImage3 = this.fuelImage3;
        activeComp.fuelImage4 = this.fuelImage4;
        activeComp.fuelImage5 = this.fuelImage5;
        activeComp.hitEffect = this.hitEffect;
        activeComp.healthbar = this.healthbar;
        activeComp.loader = this.loader;
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

    public void EndRunButton()
    {
        //done
        controller.EndRun();
    }

    public void StayOut()
    {
        //set menu is open
        controller.menuOpen = false;

        //open menu
        safeHouseMenu.SetActive(false);
    }
}
