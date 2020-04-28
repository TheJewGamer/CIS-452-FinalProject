using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SongCollection : MonoBehaviour
{
    public AudioSource audioPlayer;

    public AudioClip inspirationalTheme;
    public AudioClip electronicTheme;
    public AudioClip classicalTheme;
    public AudioClip throwbackTheme;

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
}
