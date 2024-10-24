using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game03_Movement : MonoBehaviour
{
    public float moveSpeed, rotationSpeed, gravity;

    CharacterController controller;
    Vector3 moveDirection;
    
    Vector3 randVector, gravVel;
   
    Animator anims;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anims = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    
    }

    void Update()
    {
        Move();
        Rotate();
        float speed = controller.velocity.magnitude;
        anims.SetFloat("Speed", speed);
        Debug.Log(speed);
        
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        moveDirection = moveHorizontal * transform.right + moveVertical * transform.forward;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        
    }

    void Rotate(){
        float rotHorizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(0, rotHorizontal, 0);
    }
}
