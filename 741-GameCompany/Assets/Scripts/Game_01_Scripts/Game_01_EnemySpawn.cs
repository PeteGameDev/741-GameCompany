using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_01_EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    GameObject scoreManager;
    public int enemyCount = 8;

    GameObject[] startPoint;
    void Awake(){
        scoreManager = GameObject.Find("ScoreManager");
        startPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    void Start()
    {
        for(int j = 0; j < scoreManager.GetComponent<ScoreManager>().enemyAmount; j++){
            Instantiate(enemyPrefab, startPoint[j].transform.position, Quaternion.identity);
        }
    }

}
