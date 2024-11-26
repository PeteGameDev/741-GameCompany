using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game_04_enemy : MonoBehaviour
{
    public GameObject[] targetObjects;
    public float damageAmount, attackDelay, attackRate, attackDistance, health;
    Animator anims;
    NavMeshAgent navMeshAgent;
    int targetNumber;
    bool isHit;
    void Start()
    {
        targetObjects = GameObject.FindGameObjectsWithTag("Office Worker");
        navMeshAgent = GetComponent<NavMeshAgent>();
        anims = GetComponent<Animator>();
        targetNumber = Random.Range(0, targetObjects.Length);
        navMeshAgent.speed = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > attackDelay){
            Move();
            transform.LookAt(targetObjects[targetNumber].transform);
            if(Vector3.Distance(targetObjects[targetNumber].transform.position, transform.position) <= attackDistance){
                Attack();
            }
            
        }
        else navMeshAgent.destination = transform.position;
    }

    public void TakeDamage(float amount){
        health -= amount;
        if(health <= 0){
            Destroy(gameObject);
        }
        if(isHit){
            anims.SetBool("isHit", true);
        }
        else anims.SetBool("isHit", false);
    }

    public void Attack(){
        Debug.Log("attacking");
        targetObjects[targetNumber].GetComponent<Game_04_targetHealth>().health -= damageAmount;
        attackDelay = Time.time + attackRate;
        anims.SetBool("isDancing", true);
    }

    void Move(){
        float speed = navMeshAgent.velocity.magnitude;
        anims.SetFloat("Speed", speed);
        navMeshAgent.destination = targetObjects[targetNumber].transform.position;
    }
}
