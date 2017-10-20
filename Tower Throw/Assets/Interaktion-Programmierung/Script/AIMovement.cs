using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{

    [SerializeField]
    private Transform[] waypoints;
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField]
    private int index = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[index].position);
        anim.SetFloat("speed", 1f);
    }
    
	private void Update ()
    {
		if(agent.remainingDistance < agent.stoppingDistance)
        {
            index++;
            index %= waypoints.Length;
            agent.SetDestination(waypoints[index].position);
        }
	}
}
