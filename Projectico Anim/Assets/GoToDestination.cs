using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToDestination : MonoBehaviour
{

    public Transform destination;

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        navMeshAgent.SetDestination(destination.position);

    }

    void Update()
    {
        float speed = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
        animator.SetFloat("speed", speed);

        // Check if the "Space" key is pressed and the character is not already jumping
        if (Input.GetKey("Space"))
        {
            // Trigger the "Jump" animation
            animator.SetBool("Jump", true);            
            
        }

        if (!Input.GetKey("Space"))
        {
            // Trigger the "Jump" animation
            animator.SetBool("Jump", false);

        }

    }
}
