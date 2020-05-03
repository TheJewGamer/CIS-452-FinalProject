/*
    * Jacob Cohen
    * TutGameworldLevelManager.cs
    * Final Project
    * controls the gameworld tutorial level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutGameWorldManager : MonoBehaviour
{
    //variables

    //prompts
    public GameObject prompt1;
    public GameObject prompt2;
    public GameObject prompt3;
    public GameObject prompt4;
    public GameObject prompt5;
    public GameObject prompt6;
    public GameObject prompt7;
    public GameObject prompt8;
    public GameObject prompt9;
    public GameObject prompt10;
    public GameObject prompt11;
    public GameObject prompt12;

    //gameobjects
    public Transform player;
    public Transform prompt1Target;
    public GameObject targetDummy;
    public GameObject target;
    public Transform prompt6Target;
    public Text ammoText;
    public GameObject prompt1Blocker;
    public GameObject prompt3Blocker;
    public GameObject prompt5Blocker;
    public GameObject prompt11Blocker;

    //misc
    private int promptIndex;
    public GameObject safeHouseMenu;
    private bool prompt10Waited;
    private bool prompt11Waited;


    // Start is called before the first frame update
    private void Start()
    {
        //turn off
        prompt1.SetActive(false);
        prompt2.SetActive(false);
        prompt3.SetActive(false);
        prompt4.SetActive(false);
        prompt5.SetActive(false);
        prompt6.SetActive(false);
        prompt7.SetActive(false);
        prompt8.SetActive(false);
        prompt9.SetActive(false);
        prompt10.SetActive(false);
        prompt11.SetActive(false);
        prompt12.SetActive(false);

        //set
        promptIndex = 1;
        Weapon.Ammo = 0;
        prompt10Waited = false;
        prompt11Waited = false;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        switch (promptIndex)
        {
            //prompt 1
            case 1:
                //set active
                prompt1.SetActive(true);

                //check
                if(Vector2.Distance(player.position, prompt1Target.position) <= 1f)
                {
                    //done 
                    prompt1.SetActive(false);
                    prompt1Blocker.SetActive(false);
                    promptIndex++;
                }
                break;
            //prompt 2
            case 2:
                //set active
                prompt2.SetActive(true);

                //check
                if(Input.GetKeyDown(KeyCode.F) == true)
                {
                    //done 
                    prompt2.SetActive(false);
                    promptIndex++;
                }
                break;

            //prompt 3
            case 3:
                //set active
                prompt3.SetActive(true);

                //check
                if(targetDummy == null)
                {
                    //done
                    prompt3.SetActive(false);
                    prompt3Blocker.SetActive(false);
                    promptIndex++;
                }
                break;

            //prompt4
            case 4:
                //set active
                prompt4.SetActive(true);

                //check
                if(TutWeaponController.KnifeEquipped == false)
                {
                    //done
                    prompt4.SetActive(false);
                    promptIndex++;
                }
                break;

            //prompt 5
            case 5:
                //set active
                prompt5.SetActive(true);

                //give ammo
                TutWeaponController.Ammo = 10;
                ammoText.text = TutWeaponController.Ammo.ToString();

                //check
                if(target == null)
                {
                    //done 
                    prompt5.SetActive(false);
                    prompt5Blocker.SetActive(false);
                    promptIndex++;
                }
                break;

            //prompt 6
            case 6:
                //set active
                prompt6.SetActive(true);

                //check
                if(Vector2.Distance(player.position, prompt6Target.position) <= 1f)
                {
                    //done
                    prompt6.SetActive(false);
                    promptIndex++;
                }

                break;

            //prompt 7
            case 7:
                //set active
                prompt7.SetActive(true);

                //check
                if(TutPlayerController.TotalPickUpCount == 3)
                {
                    //done
                    prompt7.SetActive(false);
                    promptIndex++;
                }
                break;

            //prompt 8
            case 8:
                //set active
                prompt8.SetActive(true);

                //check
                if(Input.GetKeyDown(KeyCode.Tab) == true)
                {
                    //done
                    prompt8.SetActive(false);
                    promptIndex++;
                }
                break;

            //prompt 9
            case 9:
                //set active
                prompt9.SetActive(true);

                //check
                if(Input.GetKeyDown(KeyCode.Tab) == true)
                {
                    //done
                    prompt9.SetActive(false);
                    promptIndex++;
                }
                break;

            //prompt 10
            case 10:
                //set active
                prompt10.SetActive(true);

                //call
                if(!prompt10Waited)
                {
                    prompt10Waited = true;
                    StartCoroutine(Prompt10Wait());
                }
                break;

            //prompt 11
            case 11:
                //set active
                prompt11.SetActive(true);
                
                //call
                if(!prompt11Waited)
                {
                    prompt11Waited = true;
                    StartCoroutine(Prompt11Wait());
                } 
                break;

            //prompt 12
            case 12:
                prompt12.SetActive(true);
                break;
            
            default:
                break;
        }
    }

    private IEnumerator Prompt10Wait()
    {
        yield return new WaitForSecondsRealtime(4);

        //done
        prompt10.SetActive(false);
        promptIndex++;
    }

    private IEnumerator Prompt11Wait()
    {
        yield return new WaitForSecondsRealtime(4);

        //done
        prompt11.SetActive(false);
        prompt11Blocker.SetActive(false);
        promptIndex++;
    }

    public void LeaveTut()
    {
        player.gameObject.GetComponent<TutPlayerController>().EndRun();
    }

    public void StayInTut()
    {
        //set menu is open
        player.gameObject.GetComponent<TutPlayerController>().menuOpen = false;

        //open menu
        safeHouseMenu.SetActive(false);
    }
}
