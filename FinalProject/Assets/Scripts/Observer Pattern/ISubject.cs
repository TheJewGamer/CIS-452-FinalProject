/*
    * Author: CJ Green
    * Script: ISubject.cs
    * Assignment: Final Project
    * Description: This script defines the subject interface
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
