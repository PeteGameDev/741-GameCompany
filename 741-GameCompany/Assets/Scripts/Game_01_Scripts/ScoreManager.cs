using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading;

public class ScoreManager : MonoBehaviour
{
    public int enemyAmount, enemyCount, score, roundNumb;
    public GameObject gameOverScreen;
    int countdownNumber = 5;
    TMP_Text scoreText, roundText;
    
    void Awake(){
        enemyAmount = PlayerPrefs.GetInt("EnemyAmount");
        enemyCount = PlayerPrefs.GetInt("EnemyCount");
        score = PlayerPrefs.GetInt("Score");
        roundNumb = PlayerPrefs.GetInt("RoundNumber");
    }
    void Start()
    {
        //Time.timeScale = 0f;
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        roundText = GameObject.Find("RoundText").GetComponent<TMP_Text>();
       
        scoreText.SetText(score.ToString());
        if(enemyAmount == 0){
            enemyAmount = 8;
            roundNumb = 1;
            score = 0;
            PlayerPrefs.DeleteAll();
            Debug.Log("Destroying Player Prefs");
        }
        roundText.DOFade(0, 2f);
    }

    
    void Update()
    {
        scoreText.SetText(score.ToString());
        roundText.SetText("ROUND " + roundNumb.ToString());
        if(enemyAmount == enemyCount){
            SceneManager.LoadScene("Game_01");
            enemyCount = 0;
            roundNumb++;
        }
        if(enemyAmount == 0){
            SceneManager.LoadScene("Game_01_Score");
        }
    }

    void LateUpdate(){
        PlayerPrefs.SetInt("EnemyAmount", enemyAmount);
        PlayerPrefs.SetInt("EnemyCount", enemyCount);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("RoundNumber", roundNumb);
    }
}
