/*
    * Jacob Cohen
    * LevelLoader.cs
    * Final Project
    * handles the loading of scenes and the animation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //variables
    private Animator anim;
    private float animTime = 1f;

    private void Start() 
    {
        //get components
        anim = gameObject.GetComponent<Animator>();
        gameObject.SetActive(true);
    }

    public IEnumerator FadeToBlack(string input)
    {
        //start animation
        anim.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(animTime);

        //load scene
        SceneManager.LoadScene(input);

    }
}
