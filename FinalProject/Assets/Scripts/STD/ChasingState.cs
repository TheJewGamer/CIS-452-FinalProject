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
        //Debug.Log("Already chasing the player");
    }
    public override void StopChasing()
    {
        controller.currentState = controller.idleState;
        controller.currentState.Init();
    }
    public override void Explode()
    {
        controller.currentState = controller.explodingState;
        controller.currentState.Init();
    }

    public override void Init()
    {
        controller.target = controller.player;
    }
}