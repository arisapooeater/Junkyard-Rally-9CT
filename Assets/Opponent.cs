using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    // set our goal as the ball
    public Transform goal;
    // grab a handle to the nav mesh agent
    private NavMeshAgent _agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // assign the handle to the component
        _agent = GetComponent<NavMeshAgent>();
        if(_agent == null){
            Debug.Log("Agent is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set our destination of the agent to the goal
        _agent.SetDestination(goal.position);
    }
}
