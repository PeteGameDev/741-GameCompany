using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game02_FinalScore : MonoBehaviour
{
    public TMP_Text finalScoreText;
    
    int finalScore;
    // Start is called before the first frame update
    void Awake()
    {
        finalScore = PlayerPrefs.GetInt("Game_02_Score");
        
    }

    void Start(){
        finalScoreText.SetText("Final Score: " + finalScore.ToString());
    }

    public void BackToWork(){
        SceneManager.LoadScene(0);
    }
}
