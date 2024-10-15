using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game02_Movement : MonoBehaviour
{
    public float moveSpeed;

    CharacterController controller;
    Vector3 moveDirection;
    Animator anims;
    Vector3 randVector;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anims = GetComponent<Animator>();
    
    }

    // Update is called once per frame
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

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Ball")){
            anims.SetBool("isHit", true);
            randVector = new Vector3(Random.Range(-0.1f, 0.1f), 1f, Random.Range(-0.1f, 0.1f));
            other.GetComponent<Rigidbody>().AddForce(randVector * Random.Range(15, 20), ForceMode.Impulse);   
        } 
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Ball")){
            anims.SetBool("isHit", false);
        }
    }
}
