﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePlacer : MonoBehaviour
{
    public GameObject fuel;
    public int fuelAmountInLevel = 1;
    public GameObject Ammo;

    public int ammoAmountInLevel = 1;

    
    public void SpawnItems()
    {
        //place Player

        
        Transform playerTransform = GameObject.FindWithTag("Player").transform;
        
    
        Transform randomSpawnPosition = SpawnPositions.instance.GetRandomSpawner();
        playerTransform.position = randomSpawnPosition.position;

        //place Safehouse exit


        Transform[] spawnsToPlayer = SpawnPositions.instance.SpawnsClosestToPlayer();
        bool[] placementCheck = new bool[spawnsToPlayer.Length];

       // prevent anything from spawning on top of the player
        for (int i = 0; i < placementCheck.Length; i ++)
        {
            if (spawnsToPlayer[i] == randomSpawnPosition)
            {
                placementCheck[i] = true;
            }
        }

        //spawn fuel in the back half of the array

        while(fuelAmountInLevel > 0)
        {
            int randomNum = Random.Range((spawnsToPlayer.Length / 2), spawnsToPlayer.Length);
            

            if (!placementCheck[randomNum])
            {
                placementCheck[randomNum] = true;
                ObjectPooler.instance.SpawnFromPool("Gas", spawnsToPlayer[randomNum].position, Quaternion.identity);
                fuelAmountInLevel--;
            }
        }

        //spawn ammo in the back 2/3 of the array

        while(ammoAmountInLevel > 0)
        {
            int randomNum2 = Random.Range(0, spawnsToPlayer.Length);
            
            if (!placementCheck[randomNum2])
            {
                Debug.Log("Spawned a thing");
                placementCheck[randomNum2] = true;
                ObjectPooler.instance.SpawnFromPool("Ammo", spawnsToPlayer[randomNum2].position, Quaternion.identity);
                ammoAmountInLevel--;
            }
        }

        //spawn some enemies in the remaining spots
        {

        }
    }
}