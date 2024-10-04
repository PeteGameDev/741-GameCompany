using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_01_EndPoint : MonoBehaviour
{
    public GameObject enemySpawn;
    int enemyNumber;

    void LateUpdate(){
        if(enemyNumber == PlayerPrefs.GetInt("EnemyCount")){
            SceneManager.LoadScene("Game_01");
        }
    }

   
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy")){
            enemyNumber++;
        }
        
    }


}
