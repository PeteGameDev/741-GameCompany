using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game02_End : MonoBehaviour
{
    public GameObject ballObject;
    void Update(){
        if(ballObject.transform.position.y <= -10){
            GameOver();
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Ball")){
            GameOver();
        }

    }

    void GameOver(){
        SceneManager.LoadScene("Game_02_Score");
    }
}
