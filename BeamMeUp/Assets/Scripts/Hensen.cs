using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Hensen : MonoBehaviour
{
    public float speedDamp = .1f;
    Transform exit;
    int speedHashParam;
    [HideInInspector]
    public NavMeshAgent agent;
    Animator anim;
    bool isExiting;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        speedHashParam = Animator.StringToHash("Speed");
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        exit = GameObject.Find("Exit").transform;

        GoToExit();
    }

    // Update is called once per frame
    void Update()
    {
        var speed = agent.desiredVelocity.magnitude;
        anim.SetFloat(speedHashParam, speed, speedDamp, Time.deltaTime);


        if (isExiting)
        {
            if (agent.remainingDistance < 6)
            {
                Destroy(gameObject);
            }
        }
    }

    public void GoToExit()
    {
        agent.SetDestination(exit.position);
        agent.isStopped = false;
        isExiting = true;
    }
}
