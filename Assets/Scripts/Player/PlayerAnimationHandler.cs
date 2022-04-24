using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {

    }

    void Update()
    {
        // Movements Animations
        if (_playerInput.Vertical != 0)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
        _animator.SetBool("IsRunning", _playerInput.IsRunning);

        // Attack Animations
        if (_playerInput.IsLightAttacking)
        {
            _animator.SetTrigger("LightAttack");
        }
        else
        {
            _animator.ResetTrigger("LightAttack");
        }
        if (_playerInput.IsHeavyAttacking)
        {
            _animator.SetTrigger("HeavyAttack");
        }
        else
        {
            _animator.ResetTrigger("HeavyAttack");
        }
    }
}