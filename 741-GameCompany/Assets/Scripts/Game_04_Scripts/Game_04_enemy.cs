using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game_04_enemy : MonoBehaviour
{
    public GameObject[] targetObjects;
    GameObject spawnObject;
    public float damageAmount, attackDelay, attackRate, attackDistance, health;
    Animator anims;
    NavMeshAgent navMeshAgent;
    int targetNumber;
    public bool isHit;
    void Start()
    {
        spawnObject = GameObject.Find("SpawnPoints");
        targetObjects = GameObject.FindGameObjectsWithTag("Office Worker");
        navMeshAgent = GetComponent<NavMeshAgent>();
        anims = GetComponent<Animator>();
        targetNumber = Random.Range(0, targetObjects.Length);
        navMeshAgent.speed = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = navMeshAgent.velocity.magnitude;
        anims.SetFloat("Speed", speed);
        if(Time.time > attackDelay){
            Move();
            //transform.LookAt(targetObjects[targetNumber].transform);
            if(Vector3.Distance(targetObjects[targetNumber].transform.position, transform.position) <= attackDistance){
                Attack();
            }
            
        }
        //else navMeshAgent.destination = transform.position;

        if(health <= 0){
            anims.SetBool("isDancing", false);
            navMeshAgent.destination = spawnObject.transform.position;
            if(Vector3.Distance(spawnObject.transform.position, transform.position) == 0){
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(float amount){
        health -= amount;
        
    }

    public void Attack(){
        Debug.Log("attacking");
        targetObjects[targetNumber].GetComponent<Game_04_targetHealth>().health -= damageAmount;
        attackDelay = Time.time + attackRate;
        anims.SetBool("isDancing", true);
    }

    void Move(){
        
        navMeshAgent.destination = targetObjects[targetNumber].transform.position;
    }
}
