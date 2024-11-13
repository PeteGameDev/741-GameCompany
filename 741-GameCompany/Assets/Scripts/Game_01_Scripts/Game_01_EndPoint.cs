using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_01_EndPoint : MonoBehaviour
{
    public GameObject enemySpawn;
    int enemyNumber;
    GameObject scoreManager;
    void Start(){
        scoreManager = GameObject.Find("ScoreManager");
    }
   
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy")){
            //enemyNumber++;
            scoreManager.GetComponent<ScoreManager>().enemyCount++;
        }
        
    }


}
