/*
    * Jake Buri
    * Bicyclist.cs
    * Final Project
    * Enemy with 1 armor
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicyclist : ArmorDecorator
{
    public Sprite brokenEnemy;

    private void Start()
    {
        SetArmor();
    }

    public override void Attacked()
    {
        if (armorValue >= 1)
        {
            armorValue--;
            this.GetComponent<SpriteRenderer>().sprite = brokenEnemy;
        }
        else
        {
            //remove enemy
            this.gameObject.SetActive(false);
        }
    }
    public override void SetArmor()
    {
        armorValue = 1;
    }
}
