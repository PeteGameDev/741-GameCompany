using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Microsoft.Unity.VisualStudio.Editor;

public class Game03_ActiveWorker : MonoBehaviour
{
    GameObject arrowImage;
    bool isFlashing;

    void Start(){
        arrowImage = this.transform.GetChild(0).gameObject;
        arrowImage.transform.DOJump(new Vector3(0, 0, 0), 0.5f, 1000, 1000f, false);
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            other.GetComponent<Game03_interaction>().hasLetter = false;
            other.GetComponent<Game03_interaction>().letterAmount--;
            this.gameObject.SetActive(false);
        }
    }

    

    
    
}
