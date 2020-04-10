/*
 * Kevon Long
 * MonsterFactory.cs
 * Assignment #6
 * determines which monster to spawn
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private GameObject enemyToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject CreateEnemy(string type)
    {
        Debug.Log("Creating " + type);
        enemyToSpawn = null;

        if (type.Equals("ExplodingEnemy"))
        {
            enemyToSpawn = EnemyPrefab;

            if (enemyToSpawn.GetComponent<EnemyControllerSTD>() == null)
            {
                enemyToSpawn.AddComponent<EnemyControllerSTD>();
            }
        }
            return enemyToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
