using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public int enemyAmount;
    public int enemyCount;
    public int score;
    TMP_Text scoreText;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        scoreText.SetText(score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(score.ToString());
        if(enemyAmount == enemyCount){
            SceneManager.LoadScene("Game_01");
            enemyCount = 0;
        }
        if(enemyAmount == 0){
            Debug.Log("Winner");
        }
    }
}
