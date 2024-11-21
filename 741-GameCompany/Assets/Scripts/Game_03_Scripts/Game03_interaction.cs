using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game03_interaction : MonoBehaviour
{
    public bool hasLetter;
    public GameObject[] officeWorkers;
    GameObject activeWorker;
    public int letterAmount;
    public TMP_Text letterAmountText;

    void Start(){
        officeWorkers = GameObject.FindGameObjectsWithTag("Office Worker");
        letterAmount = 10;
    }

    void Update(){
        letterAmountText.SetText(letterAmount.ToString());
        if(letterAmount == 0){
            SceneManager.LoadScene(5);
        }
    }

    public void PickWorker(){
        activeWorker = officeWorkers[Random.Range(0, officeWorkers.Length)];
        activeWorker.transform.GetChild(0).gameObject.SetActive(true);
    }
}
