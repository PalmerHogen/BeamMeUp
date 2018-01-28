using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Hensen : MonoBehaviour
{
    public Material[] shirts = new Material[3];
    public float speedDamp = .1f;
    public Transform exit;
    int speedHashParam;
    [HideInInspector]
    public NavMeshAgent agent;
    Animator anim;
    bool isExiting;
 
    // Use this for initialization
    void Start()
    {

        var body = transform.GetChild(0).transform.Find("Body");
        body.GetComponent<SkinnedMeshRenderer>().material = shirts[Random.Range(0, 2)];


        anim = GetComponent<Animator>();
        speedHashParam = Animator.StringToHash("Speed");
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        exit = GameObject.Find("Exit").transform;
        
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
