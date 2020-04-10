/*
 * Kevon Long
 * EnemySpawner.cs
 * Final Project Part 2
 * Spawns enemies using an object pooler and a factory pattern
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public EnemyFactory factory;

    private GameObject enemy;
    public string type;
    public float firerate;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + firerate;
            type = "ExplodingEnemy";
            enemy = factory.CreateEnemy(type);
            Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation); //put the object pooler here instead of the instantiation
        }
    }

}
