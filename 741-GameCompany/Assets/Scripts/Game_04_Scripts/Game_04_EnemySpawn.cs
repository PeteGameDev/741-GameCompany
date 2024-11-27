using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_04_EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    int spawnTime;
    
    void Start()
    {
        spawnTime = Random.Range(4, 10);
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn(){
        Instantiate(enemy, transform.position, Quaternion.identity);

    }

    
}
