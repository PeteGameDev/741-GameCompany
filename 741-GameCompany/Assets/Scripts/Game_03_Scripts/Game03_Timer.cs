using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game03_Timer : MonoBehaviour
{
    public TMP_Text timeText;
    public float totalTime;

    void Start(){
        PlayerPrefs.SetFloat("Game03_Time", 0f);
    }
    
    void Update()
    {
        totalTime += Time.deltaTime;
        float mins = Mathf.FloorToInt(totalTime / 60);
        float seconds = Mathf.FloorToInt(totalTime % 60);

        timeText.SetText(string.Format("{0:00}:{1:00}", mins, seconds));
        PlayerPrefs.SetFloat("Game03_Time", totalTime);
        
    }
}
