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
    private Vector2 direction;
    private float speed = 3f;
    public GameObject muzzelFlash;
    public GameObject hitEffect;
    private int pickupCount;
    private const int MAX_PICKUP_COUNT = 5;
    public GameObject rightCollider;
    public GameObject leftCollider;
    public Sprite rightLeftSprite;
    public Sprite upDownSprite;

    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
        muzzelFlash.SetActive(false);

        //set up
        pickupCount = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //actually moving player here
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);

        //look towards mouse
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        //transform.right= direction;

        //sprite direction anim
        if(Input.mousePosition.y > (Screen.width / 2))
        {
            //looking up
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = upDownSprite;
            rightCollider.SetActive(true);
            leftCollider.SetActive(false);
        }
        else if(Input.mousePosition.x < (Screen.width / 2))
        {
            //looking left
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rightLeftSprite;
            leftCollider.SetActive(true);
            rightCollider.SetActive(false);
        }
        else if(Input.mousePosition.x > (Screen.width / 2))
        {
            //looking right
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rightLeftSprite;
            rightCollider.SetActive(true);
            leftCollider.SetActive(false);
        }

        //Attack
        if(Input.GetMouseButtonDown(0) == true)
        {
            //feedback
            StartCoroutine(Flash());

            //raytrace
            RaycastHit2D hit = Physics2D.Raycast(transform.position, this.direction);

            if(hit.collider !=null)
            {
                //enemy hit
                if(hit.collider.CompareTag("Enemy"))
                {
                    //notify
                    hit.transform.SendMessageUpwards("Attacked");
                }
            }
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

    //muzzle flash
    private IEnumerator Flash()
    {
        //enable
        muzzelFlash.SetActive(true);

        //wait
        yield return new WaitForSeconds(.05f);

        //turn off
        muzzelFlash.SetActive(false);
    }

    public void PickUp()
    {
       
    }
}


