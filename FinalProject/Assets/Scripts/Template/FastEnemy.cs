/*
    * Jacob Cohen
    * FastEnemy.cs
    * Final Project
    * sets the stats for the fast enemy
*/

using UnityEngine;

public class FastEnemy : TemplateEnemy 
{
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