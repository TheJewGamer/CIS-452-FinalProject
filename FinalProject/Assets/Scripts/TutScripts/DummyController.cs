/*
    * Jacob Cohen
    * DummyController.cs
    * Final Project
    * controls the dummies in the tutorial level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour
{
    public void Attacked()
    {
        //remove
        Destroy(this.gameObject);
    }
}
