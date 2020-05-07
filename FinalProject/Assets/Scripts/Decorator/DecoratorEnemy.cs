/*
    * Jake Buri
    * iEnemy.cs
    * Final Project
    * Abstract enemy to be used in ArmorDecorator.cs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorEnemy : MonoBehaviour
{
    //variables
    private Transform playerLocation;
    private float speed = 2f;
    protected int health = 1;
    private int damage = 1;
    private const float DETECTION_DISTANCE = 2f;

    private void Start() 
    {
        //get player
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    private void Update() 
    {
        if (playerLocation == null)
        {
            playerLocation = GameObject.FindGameObjectWithTag("Player").transform; 
            return;
        }

        //check to see if player is in range
        if(Vector2.Distance(this.gameObject.transform.position, playerLocation.position) <= DETECTION_DISTANCE)
        {
            //move towards player
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, playerLocation.position, speed * Time.deltaTime);

            //look towards player
            this.gameObject.transform.up = playerLocation.position - transform.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //call
            other.gameObject.GetComponent<PlayerController>().Attacked(damage);

            //hide
            this.gameObject.SetActive(false);
        }    
    }

    public abstract void Attacked();
}
