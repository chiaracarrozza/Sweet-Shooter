using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
     GameObject spawnee;

    [SerializeField]
     bool stopSpawning;

    [SerializeField]
     float spawnTime;

    [SerializeField]
     float spawndelay;

    [SerializeField]
     float spawnRange;

   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects",spawnTime,spawndelay);
    }

     void Update()
    {
        
    }

    public void SpawnObjects()
    {
        Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-spawnRange, spawnRange),transform.position.y,transform.position.z + Random.Range(-spawnRange,spawnRange));

        Instantiate(spawnee,spawnPos,transform.rotation);
        if(stopSpawning)
        {
            CancelInvoke("SpawnObjects");
        }
    }
}
