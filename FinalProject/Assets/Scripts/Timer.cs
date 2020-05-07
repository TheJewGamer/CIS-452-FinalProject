/*
 * Kevon Long
 * Timer.cs
 * Final Project
 * Shows how long you've got left in the run
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float time;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        time = 60 * 5;
       // playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        time -= Time.deltaTime;
        timer.text = "" + time;

        if(time <= 0.0f)
        {
            playerController.EndRunFromTimer();
            timer.text = "";
            time = 120.0f;
        }
    }
}
