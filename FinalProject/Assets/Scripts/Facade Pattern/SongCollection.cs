using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SongCollection : MonoBehaviour
{
    public AudioSource audioPlayer;

    // Songs
    public AudioClip inspirationalTheme;
    public AudioClip electronicTheme;
    public AudioClip classicalTheme;
    public AudioClip throwbackTheme;

    // Sound Efect Audio Source
    public AudioSource soundEffects;

    // Sound Effects
    public AudioClip zombieHurt;
    public AudioClip zombieMoan;
    public AudioClip pistolShot;
    public AudioClip itemPickup;

    public GameObject playerName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerName == null)
        {
            playerName = GameObject.FindGameObjectWithTag("Player");
        }
       
        if(!audioPlayer.isPlaying)
        {
            if (playerName.name == "PlayerComp1")
            {
                audioPlayer.PlayOneShot(inspirationalTheme);
            }
            else if (playerName.name == "PlayerComp2")
            {
                audioPlayer.PlayOneShot(electronicTheme);
            }
            else if (playerName.name == "PlayerComp3")
            {
                audioPlayer.PlayOneShot(classicalTheme);
            }
            else if (playerName.name == "PlayerComp4")
            {
                audioPlayer.PlayOneShot(throwbackTheme);
            }
        }

    }

    // These functions handle playing the correct audio
    public void PlayZombieHurt()
    {   
        soundEffects.PlayOneShot(zombieHurt);
    }    
    public void PlayZombieActivate()
    {
        soundEffects.PlayOneShot(zombieMoan);
    }

    public void PlayPistolFire()
    {
        soundEffects.PlayOneShot(pistolShot);
    }

    public void ItemPickUp()
    {
        soundEffects.PlayOneShot(itemPickup);
    }

}
