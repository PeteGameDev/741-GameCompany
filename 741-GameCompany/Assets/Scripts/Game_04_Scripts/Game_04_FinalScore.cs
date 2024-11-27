using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Game_04_FinalScore : MonoBehaviour
{
    public TMP_Text finalTimeText, finalScoreText;
    float finalTime;
    int finalScore;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        finalTime = PlayerPrefs.GetFloat("Game03_Time");
        finalScore = PlayerPrefs.GetInt("Game04_Score");

        finalTimeText.SetText("Time Taken: " + finalTime.ToString());
        finalScoreText.SetText("Final Score: " + finalScore.ToString());
    }

    public void BackToWork(){
        SceneManager.LoadScene(0);
    }
}
