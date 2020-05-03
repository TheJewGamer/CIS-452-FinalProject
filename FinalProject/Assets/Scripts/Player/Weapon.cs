/*
    * Jacob Cohen, Edited by CJ on 4/28/2020
    * Weapon.cs
    * Final Project
    * controls the weapon
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    // Reference Variable to the zombie and player sounds.
    public SongCollection songCollection;

    //variables
    private Vector2 direction;
    public Sprite pistol;
    public Sprite knife;
    public Sprite muzzelFlash;
    public Sprite knifeAttack;
    public Text ammoText;
    public Text knifeReady;
    private bool melee;
    public static int ammo;
    public static bool knifeEquipped;
    public GameObject emptyText;
    public GameObject pistolHud;
    public GameObject knifeHud;
    public GameObject tiredText;

    private void Start() 
    {
        //set up
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
        pistolHud.SetActive(true);
        knifeHud.SetActive(false);
        melee = false;
        knifeEquipped = false;
        emptyText.SetActive(false);
        tiredText.SetActive(false);


        //get active runner and set ammo
        switch (Stats.ActiveRunner)
        {
            //comp 1
            case 1:
                ammo = Stats.Companion1Ammo;
                break;

            //comp 2
            case 2:
                ammo = Stats.Companion2Ammo;
                break;

            //comp 3
            case 3:
                ammo = Stats.Companion3Ammo;
                break;
            
            //comp 4
            case 4:
                ammo = Stats.Companion4Ammo;
                break;

            //testing
                default:
                    ammo = Stats.Companion1Ammo;
                    break;
        }

        //hud update
        ammoText.text = ammo.ToString();
        knifeReady.text = CanStab();
    }

    void OnEnable() 
    {
        //check to see switch weapon is equipped
        if(KnifeEquipped)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = knife;
            pistolHud.SetActive(false);
            knifeHud.SetActive(true);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
            knifeHud.SetActive(false);
            pistolHud.SetActive(true);
        }
        
        //reset
        melee = false;
        emptyText.SetActive(false);
        tiredText.SetActive(false);
        knifeReady.text = CanStab();
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
            if(Input.GetButtonDown("Shoot") == true)
            {
                //check to see if knife if equipped
                if(KnifeEquipped)
                {
                    //check to see if can attack
                    if(!melee)
                    {
                        //anim/wait
                        StartCoroutine(Stab());

                        //raytrace
                        RaycastHit2D hit = Physics2D.Raycast(transform.position, this.direction, 1);

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
                        //tired
                        StartCoroutine(Tired());
                    }
                    
                }
                //pistol is equipped
                else if(!knifeEquipped)
                {
                    //check to make sure we have ammo
                    if(ammo > 0)
                    {

                        songCollection.PlayPistolFire();

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
                        songCollection.PlayPistolOutOfAmmo();

                        //no ammo prompt
                        StartCoroutine(Empty());
                    }
                }   
            }
            //switch weapon
            else if(Input.GetButtonDown("Melee") == true && !melee)
            {
                //check if knife is equipped
                if(knifeEquipped)
                {
                    //switch to pistol
                    knifeEquipped = false;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
                    pistolHud.SetActive(true);
                    knifeHud.SetActive(false);
                }
                else
                {
                    //switch to knife
                    knifeEquipped = true;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = knife;
                    knifeHud.SetActive(true);
                    pistolHud.SetActive(false);
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

    private IEnumerator Tired()
    {
        //enable
        tiredText.SetActive(true);

        yield return new WaitForSeconds(.1f);

        //turn off
        tiredText.SetActive(false);
    }

    private IEnumerator Stab()
    {
        //enable
        this.gameObject.GetComponent<SpriteRenderer>().sprite = knifeAttack;
        melee = true;
        knifeReady.text = CanStab();

        //wait
        yield return new WaitForSeconds(2f);

        //revert
        this.gameObject.GetComponent<SpriteRenderer>().sprite = knife;
        melee = false;
        knifeReady.text = CanStab();
    }

    private string CanStab()
    {
        if(melee)
        {
            return "No";
        }
        else
        {
            return "Yes";
        }
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

    public static bool KnifeEquipped
    {
        get
        {
            return knifeEquipped;
        }
        set
        {
            knifeEquipped = value;
        }
    }
}
