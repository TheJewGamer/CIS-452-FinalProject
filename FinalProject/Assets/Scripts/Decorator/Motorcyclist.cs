/*
    * Jake Buri
    * Motorcyclist.cs
    * Final Project
    * Enemy with 2 armor
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorcyclist : Enemy
{
    private int armorValue = 3;
    public override void Attacked(GameObject player)
    {
        if (armorValue >= 0)
        {
            armorValue--;
        }
        if (armorValue == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
