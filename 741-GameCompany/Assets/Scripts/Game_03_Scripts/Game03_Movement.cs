using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game03_Movement : MonoBehaviour
{
    public float moveSpeed;

    CharacterController controller;
    Vector3 moveDirection;
    
    Vector3 randVector;
   
    Animator anims;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anims = GetComponent<Animator>();
    
    }

    void Update()
    {
        Move();
        Rotate();
        float speed = controller.velocity.magnitude;
        anims.SetFloat("Speed", speed);
        
    }

    void Move()
    {
        
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        moveDirection = moveHorizontal * transform.right + moveVertical * transform.forward;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Rotate(){
        //raycast mouse pos
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        //look at mouse pos
        if(groundPlane.Raycast(cameraRay, out rayLength)){
            Vector3 lookPoint = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(lookPoint.x, transform.position.y, lookPoint.z));
        }
    }
}
