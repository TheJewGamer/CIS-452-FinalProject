/*
    * Jake Buri
    * iEnemy.cs
    * Final Project
    * Abstract for Enemy.cs to be used in ArmorDecorator.cs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iEnemy : MonoBehaviour
{
    public abstract void Attacked(GameObject player);
}
