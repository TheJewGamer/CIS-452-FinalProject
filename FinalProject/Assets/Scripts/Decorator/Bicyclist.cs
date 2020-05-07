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
    }
    public override void SetArmor()
    {
        armorValue = 1;
    }
    public override void SetSpeed()
    {
        speed = 2f;
    }
    public override void SetDamage()
    {
        damage = 1;
    }
    public override void SetHealth()
    {
        health = 1;
    }
}
