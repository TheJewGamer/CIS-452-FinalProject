/*
    * Jacob Cohen
    * IdleState.cs
    * Final Project
    * Controls the idle state
*/

using UnityEngine;

public class IdleState : EnemyStates
{
    //variables
    private EnemyControllerSTD controller;

    private void Start() 
    {
        controller = gameObject.GetComponent<EnemyControllerSTD>();    
    }
    public override void StartChasing()
    {
        controller.currentState = controller.chasingState;
        controller.currentState.Init();
    }
    public override void StopChasing()
    {
        //Debug.Log("currently not chasing the player");
    }
    public override void Explode()
    {
        controller.currentState = controller.explodingState;
        controller.currentState.Init();
    }

    public override void Init()
    {
        controller.speed = controller.NORMAL_SPEED;
    }
}