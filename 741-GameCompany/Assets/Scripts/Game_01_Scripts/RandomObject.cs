using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    public GameObject[] bodyObject;
    // Start is called before the first frame update
    void Awake()
    {
        //bodyObject = GameObject.FindGameObjectsWithTag("Body");
        bodyObject[Random.Range(0, bodyObject.Length)].SetActive(true);
    }

    
}
