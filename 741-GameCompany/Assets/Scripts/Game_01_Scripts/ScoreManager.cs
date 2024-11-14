using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public int enemyAmount, enemyCount, score, roundNumb;
    TMP_Text scoreText, roundText;
    
    void Awake(){
        enemyAmount = PlayerPrefs.GetInt("EnemyAmount");
        enemyCount = PlayerPrefs.GetInt("EnemyCount");
        score = PlayerPrefs.GetInt("Score");
        roundNumb = PlayerPrefs.GetInt("RoundNumber");
    }
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
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
        
        //roundText.transform.DOMove(new Vector3(0, 100, 0), 5f);
        roundText.DOFade(0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(score.ToString());
        roundText.SetText("Round " + roundNumb.ToString());
        if(enemyAmount == enemyCount){
            SceneManager.LoadScene("Game_01");
            enemyCount = 0;
            roundNumb++;
        }
        if(enemyAmount == 0){
            Debug.Log("Winner");
        }
    }

    void LateUpdate(){
        PlayerPrefs.SetInt("EnemyAmount", enemyAmount);
        PlayerPrefs.SetInt("EnemyCount", enemyCount);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("RoundNumber", roundNumb);
    }
}
