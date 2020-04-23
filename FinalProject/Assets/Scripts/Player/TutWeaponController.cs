﻿/*
    * Jacob Cohen
    * TutWeaponController.cs
    * Final Project
    * controls the weapon in the tutorial level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutWeaponController : MonoBehaviour
{
    //variables
    private Vector2 direction;
    public Sprite pistol;
    public Sprite knife;
    public Sprite muzzelFlash;
    public Text ammoText;
    private bool melee;
    public static int ammo;
    public GameObject emptyText;

    private void Start() 
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
        melee = false;
        emptyText.SetActive(false);

        //set ammo
        ammo = 0;
        
        //hud update
        ammoText.text = ammo.ToString();
    }

    void OnEnable() 
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
        melee = false;
        emptyText.SetActive(false);
    }

    private void OnDisable() 
    {
        StopAllCoroutines();    
    }

    private void Update() 
    {
        //check to make sure menu is not open
        if(this.gameObject.GetComponentInParent<TutPlayerController>().menuOpen == false)
        {
            //look towards mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.right= direction;

            //shoot
            if(Input.GetButtonDown("Shoot") == true && !melee)
            {
                //check to make sure we have ammo
                if(ammo > 0)
                {
                    //feedback
                    StartCoroutine(Flash());

                    //dec ammo
                    ammo--;

                    //update hud
                    ammoText.text = ammo.ToString();

                    //raytrace
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, this.direction);

                    if(hit.collider !=null)
                    {
                        //enemy hit
                        if(hit.collider.gameObject.CompareTag("Enemy") == true)
                        {
                            //notify
                            hit.transform.SendMessageUpwards("Attacked");
                        }
                    }
                }
                else
                {
                    //no ammo prompt
                    StartCoroutine(Empty());
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
                    if(hit.collider.gameObject.CompareTag("Enemy") == true)
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

     private IEnumerator Empty()
    {
        //enable
        emptyText.SetActive(true);

        //wait
        yield return new WaitForSeconds(.1f);

        //turn off
        emptyText.SetActive(false);
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

    public static int Ammo
    {
        get
        {
            return ammo;
        }
        set
        {
            ammo = value;
        }
    }
}