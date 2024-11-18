using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_01_EndScore : MonoBehaviour
{
    public TMP_Text roundNumberText, endScoreText, finalScore;
    public int score, roundNumb;
    void Awake(){
        score = PlayerPrefs.GetInt("Score");
        roundNumb = PlayerPrefs.GetInt("RoundNumber");
    }

    // Update is called once per frame
    void Update()
    {
        roundNumberText.SetText("Rounds: " + roundNumb.ToString());
        endScoreText.SetText("Score: " + score.ToString());
        finalScore.SetText("Final Score: " + (score / roundNumb).ToString());
    }

    public void BackToWork(){
        SceneManager.LoadScene(0);
    }
}
