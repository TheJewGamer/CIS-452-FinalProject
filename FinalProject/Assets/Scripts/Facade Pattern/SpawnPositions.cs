using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    public string spawnerTag;
    public static SpawnPositions instance;

    private Transform[] spawnPoints;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetSpawnPoints()
    {
        GameObject[] tempObject = GameObject.FindGameObjectsWithTag(spawnerTag);

        spawnPoints = new Transform[tempObject.Length];

        for(int i = 0; i < tempObject.Length; i++)
        {
            spawnPoints[i] = tempObject[i].transform;
        }
    }

    public Transform[] GetSpawnArray()
    {
        return spawnPoints;
    }

    public Transform GetRandomSpawner()
    {
        Transform randomSpot;

        int randomSelection = Random.Range(0, spawnPoints.Length);

        randomSpot = spawnPoints[randomSelection];

        return randomSpot;
    }

    public Transform[] SpawnsClosestToPlayer()
    {
        //sort arrays based on distance to player

        Transform[] sortedArray = spawnPoints;

        for (int i = 0; i < spawnPoints.Length - 1; i ++)
        {
            if (distanceToPlayer(sortedArray[i]) > distanceToPlayer(sortedArray[i + 1]))
            {
                //swap

                Transform temp = sortedArray[i];

                sortedArray[i] = sortedArray[i + 1];

                sortedArray[i + 1] = temp;

                i = -1;
            }   
        }

        return sortedArray;
    }

    private float distanceToPlayer(Transform t)
    {
        return Vector2.Distance(t.position, GameObject.FindWithTag("Player").transform.position);
    }
}
