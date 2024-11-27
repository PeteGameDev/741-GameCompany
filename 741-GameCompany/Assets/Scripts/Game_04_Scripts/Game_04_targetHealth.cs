using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_04_targetHealth : MonoBehaviour
{
    public float health;
    public Slider healthSlider;

    void Start(){
        healthSlider.maxValue = health;
    }
    void Update()
    {
        healthSlider.value = health;
        if(health <= 0){
            SceneManager.LoadScene("Game_04_Score");
        }
    }
}
