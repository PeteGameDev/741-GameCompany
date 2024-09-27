using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game_01_Movement : MonoBehaviour
{

    public float moveSpeed;
    public float attackRate, attackRange;
    CharacterController controller;
    Vector3 moveDirection;
    float nextAttack;

    Animator anims;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anims = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
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
        //float moveVerical = Input.GetAxisRaw("Vertical");
        moveDirection = moveHorizontal * transform.right;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Grab(){
        nextAttack = Time.time + attackRate;
        anims.SetBool("isGrabbing", true);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, attackRange)){
            Debug.Log(hit.transform.name);
            Destroy(hit.transform.gameObject);
        }
        //Debug.Log("Is attacking");

    }
}
