/*
    * CJ, Jacob Cohen
    * SongCollection.cs
    * Final Project
    * stores the audioplayers and plays them
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SongCollection : MonoBehaviour
{
    // Songs
    public AudioSource inspirationalTheme;
    public AudioSource electronicTheme;
    public AudioSource classicalTheme;
    public AudioSource throwbackTheme;

    // Sound Effects
    public AudioSource zombieHurt;
    public AudioSource zombieMoan;
    public AudioSource pistolShot;
    public AudioSource pistolEmpty;
    public AudioSource itemPickup;

    // Start is called before the first frame update
    void Start()
    {
        switch (Stats.ActiveRunner)
        {
            case 1:
                inspirationalTheme.Play();
                break;
            case 2:
                electronicTheme.Play();
                break;
            case 3:
                classicalTheme.Play();
                break;
            case 4:
                throwbackTheme.Play();
                break;
            default:
                inspirationalTheme.Play();
                break;
        }
    }

    // These functions handle playing the correct audio
    public void PlayZombieHurt()
    {   
        zombieHurt.Play();
    }    
    public void PlayZombieActivate()
    {
       zombieMoan.Play();
    }

    public void PlayPistolFire()
    {
        pistolShot.Play();
    }

    public void PlayPistolOutOfAmmo()
    {
        pistolEmpty.Play();
    }

    public void PlayItemPickUp()
    {
        itemPickup.Play();
    }

}
