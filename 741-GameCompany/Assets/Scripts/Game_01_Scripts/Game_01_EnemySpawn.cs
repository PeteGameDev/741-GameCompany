using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_01_EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 8;

    GameObject[] startPoint;
    void Awake(){
        startPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    void Start()
    {
        for(int j = 0; j < PlayerPrefs.GetInt("EnemyCount"); j++){
            Instantiate(enemyPrefab, startPoint[j].transform.position, Quaternion.identity);
        }
    }

}
