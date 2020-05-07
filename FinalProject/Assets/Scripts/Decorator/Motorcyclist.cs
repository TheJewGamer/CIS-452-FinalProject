/*
    * Jake Buri
    * Motorcyclist.cs
    * Final Project
    * Enemy with 2 armor
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorcyclist : Bicyclist
{
    public Sprite damagedEnemy;
    public override void Attacked()
    {
        if (armorValue > 1)
        {
            armorValue--;
            this.GetComponent<SpriteRenderer>().sprite = damagedEnemy;
        }
        else if (armorValue == 1)
        {
            armorValue--;
            this.GetComponent<SpriteRenderer>().sprite = brokenEnemy;
        }
        else
        {
            if (health <= 0)
            {
                //remove enemy
                this.gameObject.SetActive(false);

            }
            else
            {
                //dec
                health--;
            }
        }

        //done
        return;
    }
    public override void SetArmor()
    {
        armorValue = 2;
    }
}
