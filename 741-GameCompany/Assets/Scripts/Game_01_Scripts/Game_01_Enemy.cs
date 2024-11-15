using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game_01_Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject[] endPoint;
    
    Animator anims;
    int endPointNum;
    public bool isHit;

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        endPoint = GameObject.FindGameObjectsWithTag("EndPoint"); //change this to tag when using multiple
        anims = GetComponent<Animator>();
        endPointNum = Random.Range(0, endPoint.Length);
        agent.speed = Random.Range(1f, 4f);
    }

    
    void Update()
    {
        float speed = agent.velocity.magnitude;
        anims.SetFloat("Speed", speed);
        Move();
        if(isHit){
            anims.SetBool("isHit", true);
        }
        else anims.SetBool("isHit", false);
    }

    void Move(){
        agent.destination = endPoint[endPointNum].transform.position;

    }
}
