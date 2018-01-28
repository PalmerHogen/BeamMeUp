using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Hensen : MonoBehaviour {
    public float speedDamp = .1f;
    public Transform Exit;
    int speedHashParam;
    NavMeshAgent agent;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        speedHashParam = Animator.StringToHash("Speed");
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;    
        GoToExit();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var speed = agent.desiredVelocity.magnitude;
        anim.SetFloat(speedHashParam, speed, speedDamp, Time.deltaTime);
	}

    void GoToExit()
    {
        agent.SetDestination(Exit.position);
        agent.isStopped = false;
      
    }
}
