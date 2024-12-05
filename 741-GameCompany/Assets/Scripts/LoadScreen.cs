using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public Slider loadSlider;
    int maxLoad = 50, loadNum; 
    
    void Start()
    {
        loadSlider.maxValue = maxLoad;
        InvokeRepeating("AddLoad", 0.5f, 1f);
    }

    void Update(){
        loadSlider.value = loadNum;
        if(loadNum >= maxLoad){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    void AddLoad()
    {
        loadNum += Random.Range(1, 10);
    }


}
