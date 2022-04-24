using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    private PlayerInput _playerInput;

    void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
        _wielder = GetComponentInParent<IStats>();
    }

    void Update()
    {
        if(_playerInput.IsLightAttacking && _canProcessNextAttack)
        {
            StartCoroutine(ProcessAttack(0.25f, _wielder.STR, GetComponentInParent<Collider>()));
        }
        else if(_playerInput.IsHeavyAttacking && _canProcessNextAttack)
        {
            StartCoroutine(ProcessAttack(0.25f, _wielder.STR * 2, GetComponentInParent<Collider>()));
        }
    }
}
