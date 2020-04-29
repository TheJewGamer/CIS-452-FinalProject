/*
    * Jacob Cohen, Edited by CJ on 4/28/2020
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
    public float EXPLOADING_DAMAGE_RANGE = 2.5f;
    private const float EXPLOADING_DISTANCE_ACTIVATION = 1f;
    public int damage = 4;
    private bool inRange;
    public Sprite explodingSprite;

    // Reference Variable to the zombie and player sounds.
    public SongCollection songCollection;

    //pattern
    public EnemyStates idleState {get; set;}
    public EnemyStates chasingState {get; set;}
    public EnemyStates explodingState {get; set;}
    public EnemyStates currentState {get; set;}

    // Start is called before the first frame update
    private void Start()
    {
        // Reference to the song collection script to play the correct audio
        songCollection = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<SongCollection>();

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

        // Plays the zombie moan sound when the player gets close to it.
        songCollection.PlayZombieActivate();
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
