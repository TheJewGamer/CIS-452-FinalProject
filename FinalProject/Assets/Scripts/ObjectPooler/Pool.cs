using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   /*
	* Warren Guiles
	 * Pool.cs
	 * Team Covid
	 * This is the pool class that is managed by the pooler.
     I took this from the example code that you showed us.
 */


[System.Serializable]
public class Pool
{

    //All of these need to be set in the inspector for each pool
    public string tag;
    public GameObject prefab;
    public int size;
    
}
