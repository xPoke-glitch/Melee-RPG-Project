using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GruntAI : MonoBehaviour
{
    [SerializeField]
    private Transform[] patrolPoints;

    private NavMeshAgent _agent;
    private StateMachine _stateMachine;
    private Grunt _grunt;

    private void Awake()
    {
        _grunt = GetComponent<Grunt>();
        _agent = GetComponent<NavMeshAgent>();

        // Randomize the collision avoidance priority
        int collsionPrio = Random.Range(0, 51);
        _agent.avoidancePriority = collsionPrio;

        _stateMachine = new StateMachine();

        // States instantiation
        var patrolling = new RandomPatrol(_agent, patrolPoints);

        // Transitions and Any-Transitions
        //_stateMachine.AddTransition(patrolling, patrolling, () => true);

        // Set the initial state
        _stateMachine.SetState(patrolling);
    }

    void Update()
    {
        _stateMachine.Tick();
    }

    private void OnEnable()
    {
        _grunt.OnDie += StopAI;
    }

    private void OnDisable()
    {
        _grunt.OnDie -= StopAI;
    }
    private void StopAI()
    {
        _stateMachine.Stop();
        _agent.isStopped = true;
    }

}
