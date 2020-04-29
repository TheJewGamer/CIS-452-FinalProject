/*
    * Jacob Cohen
    * ExploadingState.cs
    * Final Project
    * Controls the exploading state
*/

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ExplodingState : EnemyStates
{
    //variables
    private EnemyControllerSTD controller;

    private void Start() 
    {
        controller = gameObject.GetComponent<EnemyControllerSTD>();
    }

    public override void StartChasing()
    {
        //Debug.Log("Currently exploading");
    }
    public override void StopChasing()
    {
        //Debug.Log("currently exploading");
    }
    public override void Explode()
    {
        //Debug.Log("Already exploading");
    }
    public override void Init()
    {
        controller.speed = controller.EXPLODING_SPEED;
        //start exploading process
        StartCoroutine(Exploding());
    }

    private IEnumerator Exploding()
    {
        //play anim
        this.gameObject.GetComponent<SpriteRenderer>().sprite = controller.explodingSprite;

        yield return new WaitForSeconds(1.5f);

        //check to see if player is in damage range
        if(Vector2.Distance(this.gameObject.transform.position, controller.player.position) < controller.EXPLOADING_DAMAGE_RANGE)
        {
            controller.player.gameObject.GetComponent<PlayerController>().Attacked(controller.damage);
        }

        //remove enemy
        gameObject.SetActive(false);
    }
}