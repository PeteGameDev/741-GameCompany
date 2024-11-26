using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_04_Movement : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveDirection;
    Vector3 velocity;
    float gravity = -9.81f;
    public float moveSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
