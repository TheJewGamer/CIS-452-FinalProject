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
        
    }
    public override void StopChasing()
    {
        Debug.Log("currently not chasing the player");
    }
    public override void Injured()
    {

    }
    public override void Healed()
    {
        Debug.Log("not injured currently");
    }
}