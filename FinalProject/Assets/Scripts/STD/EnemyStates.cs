/*
    * Jacob Cohen
    * EnemyStates.cs
    * Final Project
    * Creates the states the enemy can use
*/

using UnityEngine;

public abstract class EnemyStates : MonoBehaviour 
{
    public abstract void StartChasing();
    public abstract void StopChasing();
    public abstract void Injured();
    public abstract void Healed();
}