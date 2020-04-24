using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyFactory : MonoBehaviour
{

    public GameObject supplyToSpawn;

    private Vector3 randomSupplySpawnPosition;

    private int maxXPositionOffSet;
    private int minXPositionOffSet;


    private int maxYPositionOffSet;
    private int minYPositionOffSet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomSupplySpawnPosition = new Vector3(Random.Range(transform.position.x + minXPositionOffSet, transform.position.x + maxXPositionOffSet), Random.Range(transform.position.y + minYPositionOffSet, transform.position.y + maxYPositionOffSet), 0);

        Debug.Log("New spawn position is: " + randomSupplySpawnPosition);
    }

    public GameObject SpawnSupplies(string supplyType)
    {

        Debug.Log("Spawning a: " + supplyType);

        supplyToSpawn = null;

        supplyToSpawn = ObjectPooler.instance.SpawnSuppliesFromPool(supplyType, randomSupplySpawnPosition, Quaternion.identity);


        return supplyToSpawn;
    }
}
