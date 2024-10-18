using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game02_Movement : MonoBehaviour
{
    public float moveSpeed;

    CharacterController controller;
    Vector3 moveDirection;
    Animator anims;
    Vector3 randVector;
    int score;
    public TMP_Text scoreText;
    
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
        scoreText.SetText(score.ToString());
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
            score++;  
        } 
        if(other.gameObject.CompareTag("Enemy")){
            SceneManager.LoadScene("Game_02");
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Ball")){
            anims.SetBool("isHit", false);
        }
    }
}
