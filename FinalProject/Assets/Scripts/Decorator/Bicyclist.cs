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
    public Enemy _thisEnemy;
    private int armorValue = 2;

    private void Start()
    {
        _thisEnemy = GetComponent<Enemy>();
    }
    public int GetArmor(Enemy enemy)
    {
        return armorValue;
    }

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
