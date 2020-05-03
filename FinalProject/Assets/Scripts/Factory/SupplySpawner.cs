/*
 * CJ Green
 * SupplySpawner.cs
 * Final Project Part 2
 * Spawns supplies with random positions using an object pooler and a factory pattern
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplySpawner : MonoBehaviour
{

    public SupplyFactory supplyFactory;

    private GameObject supply;
    public string type;
    public float firerate;
    private float nextFire;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + firerate;
            type = "";
            supply = supplyFactory.SpawnSupplies(type);

            // Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation); //put the object pooler here instead of the instantiation
        }
    }

}
