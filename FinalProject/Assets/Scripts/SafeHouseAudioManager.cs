using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeHouseAudioManager : MonoBehaviour
{

    public AudioSource mainTheme;
    public AudioSource plusButton;
    public AudioSource minusButton;


    private void Start()
    {
        mainTheme.playOnAwake = true;
        mainTheme.loop = true;
    }

    public void PlayMainTheme()
    {
        mainTheme.Play();
    }
    public void PlayPlusButton()
    {
        plusButton.Play();
    }
    public void PlayMinusButton()
    {
        minusButton.Play();
    }
}
