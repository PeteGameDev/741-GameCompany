using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Game03_LetterCollection : MonoBehaviour
{   
    GameObject[] letters;

    void Update(){
        letters = GameObject.FindGameObjectsWithTag("Letter");
    }
    
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            if(other.gameObject.GetComponent<Game03_interaction>().hasLetter == false){
                other.gameObject.GetComponent<Game03_interaction>().hasLetter = true;
                other.gameObject.GetComponent<Game03_interaction>().PickWorker();
                Destroy(letters[Random.Range(0, letters.Length)]);
            }
            Debug.Log("player in collider");
            
            
        }
    }
    

    
}


public class MovingPlatform : MonoBehaviour{

    public GameObject platform;
    public float rotateSpeed;

    void Update(){
        rotatePlatform();
    }

    void rotatePlatform(){
        //gets inputs
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical  = Input.GetAxisRaw("Vertical");

        platform.transform.Rotate(moveHorizontal * rotateSpeed, moveVertical * rotateSpeed, 0);
    }


}