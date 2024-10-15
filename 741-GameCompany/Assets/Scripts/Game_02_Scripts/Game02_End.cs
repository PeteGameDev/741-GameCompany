using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game02_End : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Ball")){
            SceneManager.LoadScene("Game_02");
        }

    }
}
