using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_04_targetHealth : MonoBehaviour
{
    public float health;
    void Update()
    {
        if(health <= 0){
            SceneManager.LoadScene("Game_04_Score");
        }
    }
}
