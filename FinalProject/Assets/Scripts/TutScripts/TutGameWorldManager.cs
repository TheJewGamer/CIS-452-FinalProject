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

    //gameobjects
    public Transform player;
    public Transform prompt1Target;
    public GameObject targetDummy;
    public GameObject target;
    public Transform prompt4Target;
    public Text ammoText;
    public GameObject prompt1Blocker;
    public GameObject prompt2Blocker;
    public GameObject prompt3Blocker;
    public GameObject prompt8Blocker;

    //misc
    private int promptIndex;
    public GameObject safeHouseMenu;


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

        //set
        promptIndex = 1;
        Weapon.Ammo = 0;
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
                if(Vector2.Distance(player.position, prompt1Target.position) <= .1f)
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
                if(targetDummy == null)
                {
                    //done 
                    prompt2.SetActive(false);
                    prompt2Blocker.SetActive(false);
                    promptIndex++;
                }
                break;
            //prompt 3
            case 3:
                //set active
                prompt3.SetActive(true);

                //give ammo
                TutWeaponController.Ammo = 10;
                ammoText.text = TutWeaponController.Ammo.ToString();

                //check
                if(target == null)
                {
                    //done 
                    prompt3.SetActive(false);
                    prompt3Blocker.SetActive(false);
                    promptIndex++;
                }

                break;

            //prompt 4
            case 4:
                //set active
                prompt4.SetActive(true);

                //check
                if(Vector2.Distance(player.position, prompt4Target.position) <= .1f)
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

                //check
                if(TutPlayerController.TotalPickUpCount == 3)
                {
                    //done
                    prompt5.SetActive(false);
                    promptIndex++;
                }
                break;
            //prompt 6
            case 6:
                //set active
                prompt6.SetActive(true);

                //check
                if(Input.GetKeyDown(KeyCode.Tab) == true)
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
                if(Input.GetKeyDown(KeyCode.Tab) == true)
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

                //call
                StartCoroutine(Prompt8Wait());
                break;
            //prompt 9
            case 9:
                //set active
                prompt9.SetActive(true);
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    private IEnumerator Prompt8Wait()
    {
        yield return new WaitForSecondsRealtime(3);

        //done
        prompt8.SetActive(false);
        prompt8Blocker.SetActive(false);
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
