using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject LevelSelectUI, PlayScreenUI, BoredUI;
    int number;
    
    public void Active(int activeNumber){
        //LevelSelectUI.SetActive(true);
        switch(activeNumber){
            case 0:
                PlayScreenUI.SetActive(true);
                break;
            case 1:
                LevelSelectUI.SetActive(true);
                break;
            case 2:
                BoredUI.SetActive(false);
                Debug.Log("ButtonClicked");
                break;
            default:
                break;
        }
    }

    public void PlayGame(int sceneNumber){
        SceneManager.LoadScene(sceneNumber);
    }

    void Start(){
        InvokeRepeating("coinFlip", 1f, 5f);
    }

    void Update(){
        if(number == 1){
            BoredUI.SetActive(true);
        }
    }

    void coinFlip(){
        number = Random.Range(0, 3);
    }
}
