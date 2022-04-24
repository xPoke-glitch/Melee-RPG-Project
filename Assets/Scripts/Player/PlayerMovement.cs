using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float turnSpeed;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        // Forward and Backward movement (W/S)
        if (!_playerInput.IsRunning)
        {
            transform.position += Time.deltaTime * _playerInput.Vertical * transform.forward * walkSpeed;
        }
        else
        {
            transform.position += Time.deltaTime * _playerInput.Vertical * transform.forward * runSpeed;
        }
        
        // Rotation (A/D)
        transform.Rotate(Vector3.up * Time.deltaTime * _playerInput.Horizontal * turnSpeed);

    }
}
