using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyFactory : MonoBehaviour
{

    public GameObject supplyToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnSupplies(string supplyType)
    {

        Debug.Log("Spawning" + supplyType);

        supplyToSpawn = null;

        supplyToSpawn = ObjectPooler.instance.SpawnFromPool(supplyType, Vector3.zero, Quaternion.identity);


        return supplyToSpawn;
    }
}
