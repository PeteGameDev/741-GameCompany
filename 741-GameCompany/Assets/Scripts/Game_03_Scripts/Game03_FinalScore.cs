using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Game03_FinalScore : MonoBehaviour
{
    public TMP_Text finalTimeText, finalScoreText;
    float finalTime;
    int finalScore;
    // Start is called before the first frame update
    void Awake()
    {
        finalTime = PlayerPrefs.GetFloat("Game03_Time");
        if(finalTime >= 0){
            finalScore += Random.Range(0, 1000);
        }
        if(finalTime >= 60){
            finalScore += Random.Range(1000, 2000);
        }
        if(finalTime >= 120){
            finalScore += Random.Range(2000, 3000);
        }
    }

    void Start(){
        finalTimeText.SetText("Time Taken: " + finalTime.ToString());
        finalScoreText.SetText("Final Score: " + finalScore.ToString());
    }

    public void BackToWork(){
        SceneManager.LoadScene(0);
    }
}
