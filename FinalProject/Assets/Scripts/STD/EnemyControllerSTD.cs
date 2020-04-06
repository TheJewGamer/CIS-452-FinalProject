/*
    * Jacob Cohen
    * EnemyControllerSTD.cs
    * Final Project
    * Controls the enemy
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerSTD : MonoBehaviour
{
    //pattern
    public EnemyStates idleState {get; set;}
    public EnemyStates chasingState {get; set;}
    public EnemyStates injuredState {get; set;}
    public EnemyStates currentState {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        idleState = gameObject.AddComponent<IdleState>();
        chasingState = gameObject.AddComponent<ChasingState>();
        injuredState = gameObject.AddComponent<InjuredState>();
        currentState = idleState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
