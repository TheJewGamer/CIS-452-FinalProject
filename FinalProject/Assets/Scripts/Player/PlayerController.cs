/*
    * Jacob Cohen
    * PlayerController.cs
    * Final Project
    * controls the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //variables
    private Vector2  movement;
    private Rigidbody2D rb2d;
    private int health = 5;
    private float speed = 3f;
    public GameObject hitEffect;
    private int pickupCount;
    private const int MAX_PICKUP_COUNT = 5;
    public GameObject rightCollider;
    public GameObject leftCollider;
    public Sprite rightLeftSprite;
    public Sprite upDownSprite;
    public GameObject rightPistol;
    public GameObject leftPistol;

    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();

        //set up
        pickupCount = 0;
        leftPistol.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);

        //sprite direction anim
        if(Input.mousePosition.y > (Screen.width / 2))
        {
            //looking up
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = upDownSprite;
            rightCollider.SetActive(true);
            leftCollider.SetActive(false);
            rightPistol.SetActive(true);
            leftPistol.SetActive(false);
        }
        else if(Input.mousePosition.x < (Screen.width / 2))
        {
            //looking left
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rightLeftSprite;
            leftCollider.SetActive(true);
            rightCollider.SetActive(false);
            rightPistol.SetActive(false);
            leftPistol.SetActive(true);
        }
        else if(Input.mousePosition.x > (Screen.width / 2))
        {
            //looking right
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rightLeftSprite;
            rightCollider.SetActive(true);
            leftCollider.SetActive(false);
            rightPistol.SetActive(true);
            leftPistol.SetActive(false);
        }
    }
    
    public void Attacked(int damage = 1)
    {
        health -= damage;

        //check
        if(health <= 0)
        {
            //dead
        }
    }


    //red flash effect
    private IEnumerator hitFlash()
    {
        //enable
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(.05f);

        hitEffect.SetActive(false);
    }

    public void PickUp()
    {
       //for future pickup stuff
    }
}


