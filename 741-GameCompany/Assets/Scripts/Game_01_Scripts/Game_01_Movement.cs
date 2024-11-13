using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Random = UnityEngine.Random;

public class Game_01_Movement : MonoBehaviour
{

    public float moveSpeed;
    public float attackRate, attackRange;
    public GameObject enemySpawner;
    public LayerMask enemyLayer;
    public GameObject scoreManager;
    CharacterController controller;
    Vector3 moveDirection;
    float nextAttack;
    Animator anims;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anims = GetComponent<Animator>();
        enemySpawner = GameObject.Find("Start Points");
        scoreManager = GameObject.Find("ScoreManager");
        //enemyAmount = PlayerPrefs.GetInt("EnemyCount");
    }

    void Update()
    {
        Move();
        //Rotate();
        float speed = controller.velocity.magnitude;
        anims.SetFloat("Speed", speed);
        if(Input.GetButtonDown("Fire1") && Time.time > nextAttack){
            Grab();
        }
        else anims.SetBool("isGrabbing", false);
        
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

    void Grab(){
        nextAttack = Time.time + attackRate;
        anims.SetBool("isGrabbing", true);
        Collider[] enemyColldiers = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach(Collider enemyCol in enemyColldiers){
            Destroy(enemyCol.gameObject);
            scoreManager.GetComponent<ScoreManager>().enemyAmount--;
            scoreManager.GetComponent<ScoreManager>().score += Random.Range(950, 1100);
        }
    }

    /*
    void Grab(){
        nextAttack = Time.time + attackRate;
        anims.SetBool("isGrabbing", true);
        RaycastHit hit;
        if(Physics.SphereCast(transform.position, attackRange, transform.forward, out hit, enemyLayer)){
            Game_01_Enemy enemy = hit.transform.GetComponent<Game_01_Enemy>();
            if(enemy != null){
                Destroy(hit.transform.gameObject);
                scoreManager.GetComponent<ScoreManager>().enemyAmount--;
                scoreManager.GetComponent<ScoreManager>().score += Random.Range(950, 1100);
            } 
        }
    }*/
   
}
