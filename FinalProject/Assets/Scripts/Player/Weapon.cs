/*
    * Jacob Cohen
    * Weapon.cs
    * Final Project
    * controls the weapons
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //variables
    private Vector2 direction;
    public Sprite pistol;
    public Sprite knife;
    public Sprite muzzelFlash;
    private bool melee;

    private void Awake() 
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
        melee = false;
    }

    void OnEnable() 
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
        melee = false;
    }

    private void OnDisable() 
    {
        StopAllCoroutines();    
    }

    private void Update() 
    {
        //check to make sure menu is not open
        if(this.gameObject.GetComponentInParent<PlayerController>().menuOpen == false)
        {
            //look towards mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.right= direction;

            //shoot
            if(Input.GetButtonDown("Shoot") == true && !melee)
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
            else if(Input.GetButtonDown("Melee") == true)
            {
                //feedback
                StartCoroutine(Knife());

                //raytrace
                RaycastHit2D hit = Physics2D.Raycast(transform.position, this.direction, 2);

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
    }
    
    //muzzle flash
    private IEnumerator Flash()
    {
        //enable
        this.gameObject.GetComponent<SpriteRenderer>().sprite = muzzelFlash;

        //wait
        yield return new WaitForSeconds(.05f);

        //turn off
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
    }

    private IEnumerator Knife()
    {
        //enable
        melee = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = knife;

        //wait
        yield return new WaitForSeconds(.5f);

        //revert
        melee = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
    }
}
