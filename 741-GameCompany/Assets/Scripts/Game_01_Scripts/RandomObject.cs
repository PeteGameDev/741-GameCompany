using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    public GameObject[] bodyObject;
    
    void Awake()
    {
        //bodyObject = GameObject.FindGameObjectsWithTag("Body");
        bodyObject[Random.Range(0, bodyObject.Length)].SetActive(true);
    }

    
}
