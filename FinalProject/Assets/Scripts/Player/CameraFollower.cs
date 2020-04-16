/*
    * Jacob Cohen
    * CameraFollower.cs
    * Final Project
    * makes the camera follower the player around
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    //variables
    public GameObject comp1;
    public GameObject comp2;
    public GameObject comp3;
    public GameObject comp4;
    private GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //get active player
        switch (Stats.ActiveRunner)
        {
            //comp 1
            case 1:
                player = comp1;
                break;

            //comp 2
            case 2:
                player = comp2;
                break;

            //comp 3
            case 3:
                player = comp3;
                break;
            
            //comp 4
            case 4:
                player = comp4;
                break;

            //testing
                default:
                    player = comp1;
                    break;

        }

        //set offset
        offset = this.transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;        
    }
}
