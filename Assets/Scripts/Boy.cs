using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boy : MonoBehaviour
{
    public Transform player;

    NavMeshAgent agent;
    Animator anim;

   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        Animating();
    }

    void Animating()
    {
        if(agent.velocity.magnitude != 0)
        {
            anim.SetBool("boyIsMoving", true);
        }
        else
        {
            anim.SetBool("boyIsMoving", false);
        }

        pivate void OnTriggerEnter (Collider other)
        {
            if(other.CompareTag("AttackPlayer"))
            {
                Destroy(gameObject);
            }
        }

    }
}
