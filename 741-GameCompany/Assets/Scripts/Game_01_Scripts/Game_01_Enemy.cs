using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game_01_Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject[] endPoint;
    Animator anims;
    int endPointNum;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        endPoint = GameObject.FindGameObjectsWithTag("EndPoint"); //change this to tag when using multiple
        anims = GetComponent<Animator>();
        endPointNum = Random.Range(0, endPoint.Length);
    }

    
    void Update()
    {
        float speed = agent.velocity.magnitude;
        anims.SetFloat("Speed", speed);
        Move();
    }

    void Move(){
        agent.destination = endPoint[endPointNum].transform.position;

    }
}
