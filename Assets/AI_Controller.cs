using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Controller : MonoBehaviour
{
    public Transform[] Goals;

    private NavMeshAgent agent;
    private Animator animator;



    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        var randGoal = Random.Range(0, Goals.Length);
        agent.destination = Goals[randGoal].transform.position;

        animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("RunOffset", Random.Range(0.1f, 0.25f));
        animator.SetTrigger("Run");

        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            GoToNextPoint();
        }
    }

    private void GoToNextPoint()
    {
        var randGoal = Random.Range(0, Goals.Length);
        agent.destination = Goals[randGoal].transform.position;
    }
}
