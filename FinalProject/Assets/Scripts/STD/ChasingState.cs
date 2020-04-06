/*
    * Jacob Cohen
    * Chasing.cs
    * Final Project
    * Controls the chasing state
*/

using UnityEngine;

public class ChasingState : EnemyStates
{
    //variables
    private EnemyControllerSTD controller;

    private void Start() 
    {
        controller = gameObject.GetComponent<EnemyControllerSTD>();    
    }
    public override void StartChasing()
    {
        Debug.Log("Already chasing the player");
    }
    public override void StopChasing()
    {
        controller.currentState = controller.idleState;
    }
    public override void Injured()
    {
        controller.currentState = controller.injuredState;
    }
    public override void Healed()
    {
        Debug.Log("Not injured");
    }
}