using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GruntAnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private Grunt _grunt;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _grunt = GetComponent<Grunt>();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(_agent.velocity.magnitude != 0)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }

    private void OnEnable()
    {
        _grunt.OnDamage += PlayHitAnimation;
        _grunt.OnDie += PlayDieAnimation;
    }

    private void OnDisable()
    {
        _grunt.OnDamage -= PlayHitAnimation;
        _grunt.OnDie -= PlayDieAnimation;
    }

    private void PlayHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }

    private void PlayDieAnimation()
    {
        _animator.SetTrigger("Die");
    }
}
