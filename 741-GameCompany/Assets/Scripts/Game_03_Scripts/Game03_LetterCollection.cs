using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Game03_LetterCollection : MonoBehaviour
{   
    
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            if(other.gameObject.GetComponent<Game03_interaction>().hasLetter == false){
                other.gameObject.GetComponent<Game03_interaction>().hasLetter = true;
                other.gameObject.GetComponent<Game03_interaction>().PickWorker();
            }
            Debug.Log("player in collider");
            
            
        }
    }
}
