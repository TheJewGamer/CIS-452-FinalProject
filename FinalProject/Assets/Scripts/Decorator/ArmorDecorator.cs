/*
    * Jake Buri
    * iEnemy.cs
    * Final Project
    * Abstract for enemies with armor
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmorDecorator : TemplatEnemy
{
    protected int armorValue;
    public abstract void SetArmor();
}
