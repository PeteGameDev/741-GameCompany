using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game02_ObjectPhysics : MonoBehaviour
{
    Rigidbody rigidbody;
    public float throwForce;
    void Start()
    {
        Vector3 throwVector = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.AddForce(throwVector * throwForce, ForceMode.Force);
    }

    void Update()
    {
        
    }
}
