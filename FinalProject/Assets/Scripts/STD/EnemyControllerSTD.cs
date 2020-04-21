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
    //variables
    public Transform target = null;
    public float speed = 2f;
    public Transform player = null;
    public float NORMAL_SPEED = 2f;
    public float EXPLODING_SPEED = 0f;
    private const float DETECTION_DISTANCE = 3f;
    private float EXPLOADING_DAMAGE_RANGE = 1f;
    private const float EXPLOADING_DISTANCE_ACTIVATION = .5f;
    public int damage = 3;
    private bool inRange;
    public Sprite explodingSprite;

    //pattern
    public EnemyStates idleState {get; set;}
    public EnemyStates chasingState {get; set;}
    public EnemyStates explodingState {get; set;}
    public EnemyStates currentState {get; set;}

    // Start is called before the first frame update
    private void Start()
    {
        //set vars and state vars
        idleState = gameObject.AddComponent<IdleState>();
        chasingState = gameObject.AddComponent<ChasingState>();
        explodingState = gameObject.AddComponent<ExplodingState>();
        currentState = idleState;
        inRange = false;
        explodingSprite = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;

        //get player
        switch (Stats.ActiveRunner)
        {
            case 1:
                player = GameObject.Find("PlayerComp1").transform;
                break;
            case 2:
                player = GameObject.Find("PlayerComp2").transform;
                break;
            case 3:
                player = GameObject.Find("PlayerComp3").transform;
                break;
            case 4:
                player = GameObject.Find("PlayerComp4").transform;
                break;
            default:
                player = GameObject.Find("PlayerComp1").transform;
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(target != null)
        {
            //move towards target
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, target.transform.position, speed * Time.deltaTime);

            //look at target
            if(target != this.gameObject.transform && inRange)
            {
                this.gameObject.transform.up = target.transform.position - transform.position;
            }

            //check to see if in exploading range
            if(Vector2.Distance(this.gameObject.transform.position, player.position) <= EXPLOADING_DISTANCE_ACTIVATION)
            {
                //call
                Exploding();
            }
        }

        //check to see if player is in range
        if(Vector2.Distance(this.gameObject.transform.position, player.position) <= DETECTION_DISTANCE)
        {
            //call
            InRange();
        }
        else
        {
            OutOfRange();
        }
    }

    public void InRange()
    {
        //start chasing
        inRange = true;
        currentState.StartChasing();
    }

    public void OutOfRange()
    {
        //stop chasing
        inRange = false;
        currentState.StopChasing();
    }

    public void Exploding()
    {
        //start exploading
        currentState.Explode();
    }

    public void Attacked()
    {
        //call
        Exploding();
    }
}
