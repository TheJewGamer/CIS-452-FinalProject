/*
 * Kevon Long
 * EnemyFactory.cs
 * Final Project
 * determines which enemy to spawn
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private GameObject enemyToSpawn;

    public GameObject CreateEnemy(string type)
    {
        Debug.Log("Creating " + type);
        enemyToSpawn = null;

        enemyToSpawn = ObjectPooler.instance.SpawnFromPool(type, Vector3.zero, Quaternion.identity);

        //check which type
        if(type == "ExploadingEnemy")
        {
            EnemyControllerSTD nullCheck = enemyToSpawn.GetComponent<EnemyControllerSTD>();

            if (nullCheck == null)
            {
                enemyToSpawn.AddComponent<EnemyControllerSTD>();
            }
        }
        else if(type == "HeavyEnemy")
        {
            HeavyEnemy nullCheck = enemyToSpawn.GetComponent<HeavyEnemy>();

            if(nullCheck == null)
            {
                enemyToSpawn.AddComponent<HeavyEnemy>();
            }
        }
    
        return enemyToSpawn;
    }
}
