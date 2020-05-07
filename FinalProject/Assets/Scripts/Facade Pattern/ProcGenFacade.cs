/*
 * Warren Guilies
 * ProcGenFacade.cs
 * Final Project
 * set up for spawning items 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGenFacade : MonoBehaviour
{
    public SpawnPositions spawnPositions;
    public ResourcePlacer resourcePlacer;

    public static ProcGenFacade instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    public void Generate()
    {
        spawnPositions.SetSpawnPoints();
        resourcePlacer.SpawnItems();
    }
}
