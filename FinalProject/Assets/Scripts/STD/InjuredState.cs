/*
    * Jacob Cohen
    * InjuredState.cs
    * Final Project
    * Controls the injured state
*/

using UnityEngine;

public class InjuredState : EnemyStates
{
    //variables
    private EnemyControllerSTD controller;

    private void Start() 
    {
        controller = gameObject.GetComponent<EnemyControllerSTD>();    
    }

    public override void StartChasing()
    {
        Debug.Log("Currently injured");
    }
    public override void StopChasing()
    {
        Debug.Log("Not chasing the player currently");
    }
    public override void Injured()
    {
        Debug.Log("Already injured");
    }
    public override void Healed()
    {
        //return to idle
        controller.currentState = controller.idleState;
    }
}