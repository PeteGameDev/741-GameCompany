using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game02_ObjectSpawn : MonoBehaviour
{
    public GameObject spawnedObject;
    public float spawnTime;
    GameObject[] spawnPoints;

    
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        InvokeRepeating("Spawn", 0.1f, spawnTime);
    }

    void Spawn(){
        GameObject clone = Instantiate(spawnedObject, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, transform.rotation);
        Destroy(clone, 10f);
    }
}
