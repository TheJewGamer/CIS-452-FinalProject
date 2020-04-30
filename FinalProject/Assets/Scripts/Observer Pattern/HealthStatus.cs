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
    public GameObject winMenu;
    public GameObject loseMenu;
    public SafeHouseAudioManager safeHouseAudioManager;
    public GameObject[] AmmoAddPrompts;
    public GameObject[] AmmoSubPrompts;
    public GameObject[] MedicalPrompts;
    public GameObject[] HealthPrompts;
    public GameObject fuelPrompt;
    public GameObject runnerPrompt;

    private void Start()
    {
        //hide menus
        winMenu.SetActive(false);
        loseMenu.SetActive(false);

        //hide prompts (Note this assumes that ammo and medical prompts are the same length)
        for(int i = 0; i < AmmoAddPrompts.Length; i++)
        {
            AmmoAddPrompts[i].SetActive(false);
            MedicalPrompts[i].SetActive(false);
            AmmoSubPrompts[i].SetActive(false);
            HealthPrompts[i].SetActive(false);
        }

        fuelPrompt.SetActive(false);
        runnerPrompt.SetActive(false);

        //reset active runner
        Stats.ActiveRunner = 0;

        //escape button
        CanEscape();

        //check to see if game is over
        if(Stats.RunsLeft == 0 && Stats.FuelSuppliesCount + Stats.CarFuel < 10)
        {
            loseMenu.SetActive(true);
        }
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
        else if(inputSlider.value <= 7 && inputSlider.value > 3)
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

            //play sound
            safeHouseAudioManager.PlayPlusButton();

            //update observers
            NotifyObservers();
        }
        else if(Stats.AmmoSuppliesCount == 0)
        {
            //which companion
            if(input.companion1)
            {
                StartCoroutine(ShowPrompt(AmmoAddPrompts[0]));
            }
            else if(input.companion2)
            {
                StartCoroutine(ShowPrompt(AmmoAddPrompts[1]));
            }
            else if(input.companion3)
            {
                StartCoroutine(ShowPrompt(AmmoAddPrompts[2]));
            }
            else if(input.companion4)
            {
                StartCoroutine(ShowPrompt(AmmoAddPrompts[3]));
            }
        }
    }

    public void AmmoSubtracted(Companion input)
    {
        //which companion
        if(input.companion1)
        {
            //check to see if companion has ammo 
            if(Stats.Companion1Ammo > 0)
            {
                Stats.Companion1Ammo--;
                Stats.AmmoSuppliesCount++;

                //play sound
                safeHouseAudioManager.PlayMinusButton();

                //update observers
                NotifyObservers();
            }
            //no ammo show prompt
            else
            {
                StartCoroutine(ShowPrompt(AmmoSubPrompts[0]));
            }   
        }
        else if(input.companion2)
        {
            //check to see if companion has ammo
            if(Stats.Companion2Ammo > 0)
            {
                Stats.Companion2Ammo--;
                Stats.AmmoSuppliesCount++;

                //play sound
                safeHouseAudioManager.PlayMinusButton();

                //update observers
                NotifyObservers();
            }
            //no ammo show prompt
            else
            {
                StartCoroutine(ShowPrompt(AmmoSubPrompts[1]));
            }
        }
        else if(input.companion3)
        {
            //check to see if companion has ammo
            if(Stats.Companion3Ammo > 0)
            {
                Stats.Companion3Ammo--;
                Stats.AmmoSuppliesCount++;

                //play sound
                safeHouseAudioManager.PlayMinusButton();

                //update observers
                NotifyObservers();
            }
            //no ammo show prompt
            else
            {
                StartCoroutine(ShowPrompt(AmmoSubPrompts[2]));
            }
        }
        else if(input.companion4 && Stats.Companion4Ammo > 0)
        {
            //check to see if companion has ammo
            if(Stats.Companion4Ammo > 0)
            {
                Stats.Companion4Ammo--;
                Stats.AmmoSuppliesCount++;

                //play sound
                safeHouseAudioManager.PlayMinusButton();

                //update observers
                NotifyObservers();
            }
            //no ammo show prompt
            else
            {
                StartCoroutine(ShowPrompt(AmmoSubPrompts[3]));
            }
        }
    }

    public void Healed(Companion input)
    {
        //check to see if we have medical
        if(Stats.MedicalSuppliesCount > 0)
        {
            //which companion
            if(input.companion1)
            {
                //make sure not at full health
                if(Stats.Companion1Health < Stats.MaxHealth)
                {
                    //set health and update supplies
                    Stats.Companion1Health = Stats.MaxHealth;
                    Stats.MedicalSuppliesCount--;

                    //play sound
                    safeHouseAudioManager.PlayPlusButton();

                    //update observers
                    NotifyObservers();
                }
                //at full health
                else
                {
                    //prompt
                    StartCoroutine(ShowPrompt(HealthPrompts[0]));
                }
            }
            else if(input.companion2)
            {
                //make sure not at full health
                if(Stats.Companion2Health < Stats.MaxHealth)
                {
                    //set health and update supplies
                    Stats.Companion2Health = Stats.MaxHealth;
                    Stats.MedicalSuppliesCount--;

                    //play sound
                    safeHouseAudioManager.PlayPlusButton();

                    //update observers
                    NotifyObservers();
                }
                //at full health
                else
                {
                    //prompt
                    StartCoroutine(ShowPrompt(HealthPrompts[1]));
                }
            }
            else if(input.companion3)
            {
                //make sure not at full health
                if(Stats.Companion3Health < Stats.MaxHealth)
                {
                    //set health and update supplies
                    Stats.Companion3Health = Stats.MaxHealth;
                    Stats.MedicalSuppliesCount--;

                    //play sound
                    safeHouseAudioManager.PlayPlusButton();

                    //update observers
                    NotifyObservers();
                }
                //at full health
                else
                {
                    //prompt
                    StartCoroutine(ShowPrompt(HealthPrompts[2]));
                }
            }
            else if(input.companion4)
            {
                //make sure not at full health
                if(Stats.Companion4Health < Stats.MaxHealth)
                {
                    //set health and update supplies
                    Stats.Companion4Health = Stats.MaxHealth;
                    Stats.MedicalSuppliesCount--;

                    //play sound
                    safeHouseAudioManager.PlayPlusButton();

                    //update observers
                    NotifyObservers();
                }
                //at full health
                else
                {
                    //prompt
                    StartCoroutine(ShowPrompt(HealthPrompts[3]));
                }
            }
        }
        //no supplies
        else if(Stats.MedicalSuppliesCount == 0)
        {
            //which companion
            if(input.companion1)
            {
                StartCoroutine(ShowPrompt(MedicalPrompts[0]));
            }
            else if(input.companion2)
            {
                StartCoroutine(ShowPrompt(MedicalPrompts[1]));
            }
            else if(input.companion3)
            {
                StartCoroutine(ShowPrompt(MedicalPrompts[2]));
            }
            else if(input.companion4)
            {
                StartCoroutine(ShowPrompt(MedicalPrompts[3]));
            }
        }
    }

    public void AddFuel()
    {
        //check to make sure we have fuel
        if(Stats.FuelSuppliesCount > 0)
        {
            //check to make sure car is not already full
            if(Stats.CarFuel < Stats.MaxFuel)
            {
                //add fuel
                Stats.CarFuel++;
                Stats.FuelSuppliesCount--;
            
                //update observers
                NotifyObservers();

                //check to see if we can escape
                CanEscape();
            }
        }
        //no fuel
        else if(Stats.FuelSuppliesCount == 0)
        {
            //prompt
            StartCoroutine(ShowPrompt(fuelPrompt));
        }
    }

    private void CanEscape()
    {
        //check
        if(Stats.CarFuel == Stats.MaxFuel)
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
        winMenu.SetActive(true);
    }

    public void startRun()
    {
        if(Stats.RunsLeft == 0)
        {
            loseMenu.SetActive(true);
        }
        else if(Stats.ActiveRunner != 0)
        {
            //subtract run
            Stats.RunsLeft--;

            //load gameworld
            loader.StartCoroutine("FadeToBlack", "GameWorld");
        }
        else if(Stats.ActiveRunner == 0)
        {
            //prompt
            StartCoroutine(ShowPrompt(runnerPrompt));
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

        NotifyObservers();
    }

    private void Dead()
    {
        if(Stats.Companion1Health == 0 && Stats.Companion2Health == 0 && Stats.Companion3Health == 0 && Stats.Companion4Health == 0)
        {
            //game over
            loseMenu.SetActive(true);
        }
    }

    private IEnumerator ShowPrompt(GameObject input)
    {
        //enable
        input.SetActive(true);

        //wait
        yield return new WaitForSecondsRealtime(3);

        //disable
        input.SetActive(false);
    }
}
