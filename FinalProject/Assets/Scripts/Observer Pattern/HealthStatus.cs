/*
    * Author: CJ Green, Jacob Cohen
    * Script: HealthStatus.cs
    * Assignment: Final Project
    * Description: This script defines and fills out the subject that inherits from the ISubject interface. It also is the general manager for the Safehouse menu as it keeps track of the required information already 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthStatus : MonoBehaviour, ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    public List<Companion> companions = new List<Companion>();
    public GameObject escapeButton;
    public LevelLoader loader;

    void Start()
    {
        Debug.Log("The total amount of observers is: " + observers.Count);

        foreach (IObserver observer in observers)
        {
            Debug.Log("This is observer: " + observer.ToString());
        }

        Debug.Log("The total amount of companions is: " + companions.Count);

        foreach (Companion companion in companions)
        {
            Debug.Log("This companion is: " + companion.ToString());
        }

        //runs left
        

        //escape button
        CanEscape();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);

        if (companions != null)
        {
            observer.UpdateData(companions);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.UpdateData(companions);
            Debug.Log("UpdateData was called from Notify Observers");
        }
    }

    public void AddCompanions(Companion companion)
    {
        companions.Add(companion);

        NotifyObservers();
    }

    public void ColorHealthCheck(Slider inputSlider)
    {
        //variable
        ColorBlock cb = inputSlider.colors;

        //check to see if dead
        if(inputSlider.value <= 0)
        {
            //check to see if everyone is dead
            Dead();
        }

        //color change/confirm
        if(inputSlider.value > 7)
        {
            //set color to green
            cb.disabledColor = Color.green;
            inputSlider.colors = cb;
        }
        else if(inputSlider.value < 7 && inputSlider.value > 3)
        {
            //set color to yellow
            cb.disabledColor = Color.yellow;
            inputSlider.colors = cb;
        }
        else
        {
            //set color to red
            cb.disabledColor = Color.red;
            inputSlider.colors = cb;
        }

    }

    public void AmmoAdded(Companion input)
    {
        //check to see if we have ammo
        if(Stats.AmmoSuppliesCount > 0)
        {
            //which companion
            if(input.companion1)
            {
                Stats.Companion1Ammo++;
                Stats.AmmoSuppliesCount--;
            }
            else if(input.companion2)
            {
                Stats.Companion2Ammo++;
                Stats.AmmoSuppliesCount--;
            }
            else if(input.companion3)
            {
                Stats.Companion3Ammo++;
                Stats.AmmoSuppliesCount--;
            }
            else if(input.companion4)
            {
                Stats.Companion4Ammo++;
                Stats.AmmoSuppliesCount--;
            }
            else
            {
                Debug.Log("Error on adding ammo");
            }

            //update observers
            NotifyObservers();
        }
        else
        {
            //no ammo
        }
    }

    public void AmmoSubtracted(Companion input)
    {
        //check to see if we have ammo
        if(input.companion1)
        {
            Stats.Companion1Ammo--;
            Stats.AmmoSuppliesCount++;
        }
        else if(input.companion2)
        {
            Stats.Companion2Ammo--;
            Stats.AmmoSuppliesCount++;
        }
        else if(input.companion3)
        {
            Stats.Companion3Ammo--;
            Stats.AmmoSuppliesCount++;
        }
        else if(input.companion4)
        {
            Stats.Companion4Ammo--;
            Stats.AmmoSuppliesCount++;
        }
        else
        {
            Debug.Log("Error on adding ammo");
        }

        //update observers
        NotifyObservers();
    }

    public void Healed(Companion input)
    {
        //check to see if we have medical
        if(Stats.MedicalSuppliesCount > 0)
        {
            //which companion
            if(input.companion1 && Stats.Companion1Health < 10 && !Stats.Companion1Dead)
            {
                Stats.Companion1Health++;
                Stats.MedicalSuppliesCount--;
            }
            else if(input.companion2 && Stats.Companion2Health < 10 && !Stats.Companion2Dead)
            {
                Stats.Companion2Health++;
                Stats.MedicalSuppliesCount--;
            }
            else if(input.companion3 && Stats.Companion3Health < 10 && !Stats.Companion3Dead)
            {
                Stats.Companion3Health++;
                Stats.MedicalSuppliesCount--;
            }
            else if(input.companion4 && Stats.Companion4Health < 10 && !Stats.Companion4Dead)
            {
                Stats.Companion4Health++;
                Stats.MedicalSuppliesCount--;
            }
            else
            {
                Debug.Log("Error on adding health");
            }

            //update observers
            NotifyObservers();
        }
        else
        {
            //no health
            Debug.Log("No health supplies");
        }
    }

    public void AddFuel()
    {
        //check to make sure we have fuel
        if(Stats.FuelSuppliesCount > 0)
        {
            //check to make sure car is not already full
            if(Stats.CarFuel < 10)
            {
                //add fuel
                Stats.CarFuel++;
                Stats.FuelSuppliesCount--;
            }

            //update observers
            NotifyObservers();

            //check to see if we can escape
            CanEscape();
        }
    }

    private void CanEscape()
    {
        //check
        if(Stats.CarFuel == 10)
        {
            escapeButton.SetActive(true);
        }
        else
        {
            escapeButton.SetActive(false);
        }
    }

    public void Escape()
    {
        //win menu
    }

    public void startRun()
    {
        if(Stats.RunsLeft == 0)
        {
            //lose
        }
        else if(Stats.ActiveRunner != 0)
        {
            //subtract run
            Stats.RunsLeft--;

            //load gameworld
            loader.StartCoroutine("FadeToBlack", "GameWorld");
        }
    }

    public void SetRunner(Companion input)
    {
        if(input.companion1)
        {
            Stats.ActiveRunner = 1;
        }
        else if(input.companion2)
        {
            Stats.ActiveRunner = 2;
        }
        else if(input.companion3)
        {
            Stats.ActiveRunner = 3;
        }
        else if(input.companion4)
        {
            Stats.ActiveRunner = 4;
        }
        else
        {
            Debug.Log("Error on setting active runner");
        }

        NotifyObservers();
    }

    private void Dead()
    {
        if(Stats.Companion1Health == 0 && Stats.Companion2Health == 0 && Stats.Companion3Health == 0 && Stats.Companion4Health == 0)
        {
            //game over
        }
    }
}
