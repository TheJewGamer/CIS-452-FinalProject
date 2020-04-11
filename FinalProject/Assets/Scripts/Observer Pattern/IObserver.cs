/*
    * Author: CJ Green
    * Script: IObserver.cs
    * Assignment: Final Project
    * Description: This script defines the observer interface
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver 
{
    void UpdateData(List<Companion> companions);
}
