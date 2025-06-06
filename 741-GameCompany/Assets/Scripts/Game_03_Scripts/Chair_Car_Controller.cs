using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair_Car_Controller : MonoBehaviour
{
    public Rigidbody sphereRB;
    public float fwdSpeed, revSpeed, turnSpeed;
    float moveInput, turnInput;

    void Start(){
        sphereRB.transform.parent = null;
    }

    void Update(){
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        moveInput += moveInput > 0 ? fwdSpeed : revSpeed;

        transform.position = sphereRB.transform.position;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);
    }

    void FixedUpdate(){
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
