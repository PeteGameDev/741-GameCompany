using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    public AudioClip[] audioSources;
    public AudioSource randomSound;

    public GameObject LevelSelectUI, PlayScreenUI, BoredUI;
    public UnityEngine.UI.Image Fill2;
    int number;
    bool isFlashing = true;
    
    public void Active(int activeNumber){
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
        InvokeRepeating("coinFlip", 5f, 5f);
        InvokeRepeating("IconFlash", 0.5f, 0.5f);
        RandomAudio();
    }

    void Update(){
        if(number == 1){
            BoredUI.SetActive(true);
        }
        if(number == 2){
            RandomAudio();
        }
    }

    void coinFlip(){
        number = Random.Range(0, 3);
        
    }
    void IconFlash(){
        if(isFlashing == true){
            Fill2.DOFade(0f, 0.01f);
            isFlashing = false;
        }
        else if(isFlashing == false){
            Fill2.DOFade(1f, 0.01f);
            isFlashing = true;
        }
    }

    void RandomAudio(){
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
    }

    public void Quit(){
        Application.Quit();
    }
}
