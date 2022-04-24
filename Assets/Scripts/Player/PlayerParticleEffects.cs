using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleEffects : MonoBehaviour
{
    [SerializeField] 
    private ParticleSystem smokeSprintEffect;
    [SerializeField]
    private ParticleSystem weaponParticleEffect;

    private PlayerInput _playerInput;

    private bool _sprintSmokePlayed;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        _sprintSmokePlayed = false;
    }

    void Update()
    {
        if (_playerInput.IsRunning && (!_sprintSmokePlayed))
        {
            _sprintSmokePlayed = true;
            smokeSprintEffect.Play();
        }
        if (!_playerInput.IsRunning)
        {
            _sprintSmokePlayed = false;
        }

        if((_playerInput.IsHeavyAttacking || _playerInput.IsLightAttacking))
        {
            weaponParticleEffect.Play();
        }
    }
}
