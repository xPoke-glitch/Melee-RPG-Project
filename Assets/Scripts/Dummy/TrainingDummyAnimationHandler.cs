using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummyAnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private TrainingDummy _trainingDummy;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _trainingDummy = GetComponent<TrainingDummy>();
    }

    private void OnEnable()
    {
        _trainingDummy.OnDie += PlayDieAnimation;
        _trainingDummy.OnDamage += PlayHitAnimation;
    }

    private void OnDisable()
    {
        _trainingDummy.OnDie -= PlayDieAnimation;
        _trainingDummy.OnDamage -= PlayHitAnimation;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void PlayDieAnimation()
    {
        _animator.SetTrigger("IsDead");
        _animator.SetTrigger("Reset");
    }

    private void PlayHitAnimation()
    {
        _animator.SetTrigger("GotHit");
    }
}
