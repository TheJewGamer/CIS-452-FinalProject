/*
 * Kevon Long
 * EnemySpawner.cs
 * Final Project
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
    public GameObject[] enemiesInGame;


    // Update is called once per frame
    void Update()
    {
        enemiesInGame = GameObject.FindGameObjectsWithTag("Enemy");

        if(Time.time > nextFire && enemiesInGame.Length <= 5)
        {
            Debug.Log("exp");
            nextFire = Time.time + firerate;
            type = "ExplodingEnemy";
            enemy = factory.CreateEnemy(type);

            enemy.transform.position = transform.position;
        }

        if(Time.time > nextFire && enemiesInGame.Length <= 5)
        {
            Debug.Log("heavy");
            nextFire = Time.time + firerate;
            type = "HeavyEnemy";
            enemy = factory.CreateEnemy(type);

            enemy.transform.position = transform.position;
        }
    }

}
