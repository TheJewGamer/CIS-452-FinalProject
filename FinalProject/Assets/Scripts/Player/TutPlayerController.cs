﻿/*
    * Jacob Cohen
    * TutPlayerController.cs
    * Final Project
    * controls the player in the tutorial level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutPlayerController : MonoBehaviour
{
    //variables
    private Vector2  movement;
    private Rigidbody2D rb2d;
    private float health;
    private float speed = 3f;
    public GameObject hitEffect;
    private static int medicalSupplyCount;
    private static int fuelSupplyCount;
    private static int ammoSupplyCount;
    private static int totalPickUpCount;
    private const int MAX_PICKUP_COUNT = 5;
    public Slider healthbar;
    private GameObject rightCollider;
    private GameObject leftCollider;
    private Sprite rightLeftSprite;
    private Sprite upDownSprite;
    public GameObject rightPistol;
    public GameObject leftPistol;
    public bool menuOpen;

    //menu variables
    public GameObject inventoryMenu;
    public GameObject safeHouseMenu;

    public GameObject ammoImage1;
    public GameObject ammoImage2;
    public GameObject ammoImage3;
    public GameObject ammoImage4;
    public GameObject ammoImage5;

    public GameObject healthImage1;
    public GameObject healthImage2;
    public GameObject healthImage3;
    public GameObject healthImage4;
    public GameObject healthImage5;

    public GameObject fuelImage1;
    public GameObject fuelImage2;
    public GameObject fuelImage3;
    public GameObject fuelImage4;
    public GameObject fuelImage5;
    public LevelLoader loader;
    public Text inventoryCountText;
    public SongCollection songCollection;


    // Start is called before the first frame update
    void Start()
    {
        //get componets
        rb2d = this.GetComponent<Rigidbody2D>();
        rightLeftSprite = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        upDownSprite = this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
        leftCollider = this.gameObject.transform.GetChild(2).gameObject;
        rightCollider = this.gameObject.transform.GetChild(3).gameObject;

        //set tag to player
        this.gameObject.tag = "Player";

        //weapon stuff
        rightPistol = this.gameObject.transform.GetChild(4).gameObject;
        leftPistol = this.gameObject.transform.GetChild(5).gameObject;
        leftPistol.SetActive(false);

        //inventory stuff
        medicalSupplyCount = 0;
        fuelSupplyCount = 0;
        ammoSupplyCount = 0;
        totalPickUpCount = 0;

        //hud stuff
        menuOpen = false;
        inventoryMenu.SetActive(false);
        ammoImage1.SetActive(false);
        ammoImage2.SetActive(false);
        ammoImage3.SetActive(false);
        ammoImage4.SetActive(false);
        ammoImage5.SetActive(false);
        healthImage1.SetActive(false);
        healthImage2.SetActive(false);
        healthImage3.SetActive(false);
        healthImage4.SetActive(false);
        healthImage5.SetActive(false);
        fuelImage1.SetActive(false);
        fuelImage2.SetActive(false);
        fuelImage3.SetActive(false);
        fuelImage4.SetActive(false);
        fuelImage5.SetActive(false);

        //set
        health = 10;

        //call
        UpdateHealthBar();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //make sure menu is not open
        if(!menuOpen)
        {
            //make sure not dead
            if(health > 0)
            {
                //actually moving player here
                rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
            }
            
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

        //open/close menu
        if(Input.GetKeyDown(KeyCode.Tab) == true && !safeHouseMenu.activeSelf)
        {
            //open
            if(!menuOpen)
            {
                //var update
                menuOpen = true;

                //turn on menu
                inventoryMenu.SetActive(true);
            }
            else
            {
                //var update
                menuOpen = false;

                //turn off menu
                inventoryMenu.SetActive(false);
            }
        }
        
    }
    
    public void Attacked(int damage = 1)
    {
        //dec health
        health -= damage;

        //feedback
        StartCoroutine(hitFlash());

        //hud
        UpdateHealthBar();

        //check
        if(health <= 0)
        {
            //back to safehouse
            EndRun();
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //ammo pickup
        if(other.gameObject.tag == "Ammo")
        {
            //space check
            if(totalPickUpCount < MAX_PICKUP_COUNT)
            {
                songCollection.PlayItemPickUp();

                //inc pickup count
                totalPickUpCount++;
                ammoSupplyCount++;

                //add to hud
                switch (ammoSupplyCount)
                {
                    case 1:
                        ammoImage1.SetActive(true);
                        break;
                    case 2:
                        ammoImage2.SetActive(true);
                        break;
                    case 3:
                        ammoImage3.SetActive(true);
                        break;
                    case 4:
                        ammoImage4.SetActive(true);
                        break;
                    case 5:
                        ammoImage5.SetActive(true);
                        break;
                    default:
                        Debug.Log("Error in Ammo pickup");
                        break;
                }

                //destroy pickup
                Destroy(other.gameObject);

                //update text
                inventoryCountText.text = totalPickUpCount.ToString();
            }
        }
        else if(other.gameObject.tag == "Health")
        {
            //space check
            if(totalPickUpCount < MAX_PICKUP_COUNT)
            {
                songCollection.PlayItemPickUp();

                //inc pickup count
                totalPickUpCount++;
                medicalSupplyCount++;

                //add to hud
                switch (medicalSupplyCount)
                {
                    case 1:
                        healthImage1.SetActive(true);
                        break;
                    case 2:
                        healthImage2.SetActive(true);
                        break;
                    case 3:
                        healthImage3.SetActive(true);
                        break;
                    case 4:
                        healthImage4.SetActive(true);
                        break;
                    case 5:
                        healthImage5.SetActive(true);
                        break;
                    default:
                        Debug.Log("Error in health Pickup");
                        break;
                }

                //destroy pickup
                Destroy(other.gameObject);

                //update text
                inventoryCountText.text = totalPickUpCount.ToString();
            }
        }
        else if(other.gameObject.tag == "Gas")
        {
            //space check
            if(totalPickUpCount < MAX_PICKUP_COUNT)
            {
                songCollection.PlayItemPickUp();

                //inc pickup count
                totalPickUpCount++;
                fuelSupplyCount++;

                //add to hud
                switch (fuelSupplyCount)
                {
                    case 1:
                        fuelImage1.SetActive(true);
                        break;
                    case 2:
                        fuelImage2.SetActive(true);
                        break;
                    case 3:
                        fuelImage3.SetActive(true);
                        break;
                    case 4:
                        fuelImage4.SetActive(true);
                        break;
                    case 5:
                        fuelImage5.SetActive(true);
                        break;
                    default:
                        Debug.Log("Error in Fuel Pickup");
                        break;
                }

                //destroy pickup
                Destroy(other.gameObject);

                //update text
                inventoryCountText.text = totalPickUpCount.ToString();
            }
        }
        else if(other.gameObject.tag == "Safehouse")
        {
            //set menu is open
            menuOpen = true;

            //open menu
            safeHouseMenu.SetActive(true);
        }
    }

    public void MedicalDrop()
    {
        //check to make sure we have medical supplies
        switch (medicalSupplyCount)
        {
            case 1:
                healthImage1.SetActive(false);
                medicalSupplyCount--;
                totalPickUpCount--;
                break;
            case 2:
                healthImage2.SetActive(false);
                medicalSupplyCount--;
                totalPickUpCount--;
                break;
            case 3:
                healthImage3.SetActive(false);
                medicalSupplyCount--;
                totalPickUpCount--;
                break;
            case 4:
                healthImage4.SetActive(false);
                medicalSupplyCount--;
                totalPickUpCount--;
                break;
            case 5:
                healthImage5.SetActive(false);
                medicalSupplyCount--;
                totalPickUpCount--;
                break;
            default:
                Debug.Log("No medical supplies in inventory");
                break;
        }

        //update text
        inventoryCountText.text = totalPickUpCount.ToString();
    }

    public void FuelDrop()
    {
        //check to make sure we have medical supplies
        switch (fuelSupplyCount)
        {
            case 1:
                fuelImage1.SetActive(false);
                fuelSupplyCount--;
                totalPickUpCount--;
                break;
            case 2:
                fuelImage2.SetActive(false);
                fuelSupplyCount--;
                totalPickUpCount--;
                break;
            case 3:
                fuelImage3.SetActive(false);
                fuelSupplyCount--;
                totalPickUpCount--;
                break;
            case 4:
                fuelImage4.SetActive(false);
                fuelSupplyCount--;
                totalPickUpCount--;
                break;
            case 5:
                fuelImage5.SetActive(false);
                fuelSupplyCount--;
                totalPickUpCount--;
                break;
            default:
                Debug.Log("No fuel supplies in inventory");
                break;
        }

        //update text
        inventoryCountText.text = totalPickUpCount.ToString();
    }

    public void AmmoDrop()
    {
        //check to make sure we have ammo supplies
        switch (ammoSupplyCount)
        {
            case 1:
                ammoImage1.SetActive(false);
                ammoSupplyCount--;
                totalPickUpCount--;
                break;
            case 2:
                ammoImage2.SetActive(false);
                ammoSupplyCount--;
                totalPickUpCount--;
                break;
            case 3:
                ammoImage3.SetActive(false);
                ammoSupplyCount--;
                totalPickUpCount--;
                break;
            case 4:
                ammoImage4.SetActive(false);
                ammoSupplyCount--;
                totalPickUpCount--;
                break;
            case 5:
                ammoImage5.SetActive(false);
                ammoSupplyCount--;
                totalPickUpCount--;
                break;
            default:
                Debug.Log("No ammo supplies in inventory");
                break;
        }

        //update text
        inventoryCountText.text = totalPickUpCount.ToString();
    }

    private void UpdateHealthBar()
    {
        //update healthbar
        healthbar.value = health;

        //variable
        ColorBlock cb = healthbar.colors;

        //check to see if dead
        if(healthbar.value <= 0)
        {
            //call
            EndRun();
        }

        //color change/confirm
        if(healthbar.value > 7)
        {
            //set color to green
            cb.disabledColor = Color.green;
            healthbar.colors = cb;
        }
        else if(healthbar.value <= 7 && healthbar.value > 3)
        {
            //set color to yellow
            cb.disabledColor = Color.yellow;
            healthbar.colors = cb;
        }
        else
        {
            //set color to red
            cb.disabledColor = Color.red;
            healthbar.colors = cb;
        }
    }

    public void EndRun()
    {
        //exit back to safehouse
        loader.StartCoroutine("FadeToBlack", "Safehouse");
    }

    public static int TotalPickUpCount
    {
        get
        {
            return totalPickUpCount;
        }
        set
        {
            totalPickUpCount = value;
        }
    }

}


