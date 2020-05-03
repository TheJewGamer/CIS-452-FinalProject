/*
    * Jacob Cohen
    * HeavyEnemy.cs
    * Final Project
    * sets the stats for the heavy enemy
*/

using UnityEngine;

public class HeavyEnemy : TemplatEnemy 
{
    public override void SetSpeed()
    {
        speed = 1f;
    }
    public override void SetDamage()
    {
        damage = 2;
    }
    public override void SetHealth()
    {
        health = 3;
    }
}