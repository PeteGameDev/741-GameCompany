using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_04_Movement : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveDirection;
    Vector3 velocity;
    float gravity = -9.81f;
    public float moveSpeed, lookSpeed;

    public Camera cam;

    float maxX = 60f, minX = -60f, rotX = 0, rotY = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraRot();
    }

    void Move(){
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void CameraRot(){
        rotX += Input.GetAxis("Mouse Y") * lookSpeed;
        rotY += Input.GetAxis("Mouse X") * lookSpeed;
        rotX = Mathf.Clamp(rotX, minX, maxX);

        transform.localEulerAngles = new Vector3 (0, rotY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);
    }
}
