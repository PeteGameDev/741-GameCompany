using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_01_EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;

    GameObject[] startPoint;
    void Awake(){
        startPoint = GameObject.FindGameObjectsWithTag("StartPoint");
        enemyCount = startPoint.Length;
        for(int i = 0; i < startPoint.Length; i++){
            for(int j = 0; j < enemyCount; i++){
                Instantiate(enemyPrefab, startPoint[i].transform.position, Quaternion.identity);
            }
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Spawn();
        }
    }
    
    void Spawn(){
        for(int i = 0; i < startPoint.Length; i++){
            for(int j = 0; j < enemyCount; i++){
                Instantiate(enemyPrefab, startPoint[i].transform.position, Quaternion.identity);
            }
        }
    }
}
