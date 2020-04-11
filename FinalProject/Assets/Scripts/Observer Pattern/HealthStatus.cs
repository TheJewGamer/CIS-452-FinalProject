/*
    * Author: CJ Green
    * Script: HealthStatus.cs
    * Assignment: Final Project
    * Description: This script defines and fills out the subject that inherits from the ISubject interface
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatus : MonoBehaviour, ISubject
{

    private List<IObserver> observers = new List<IObserver>();

    public List<Companion> companions = new List<Companion>();


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
}
