using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool IsRunning { get; private set; }

    public bool IsLightAttacking { get; private set; }
    public bool IsHeavyAttacking { get; private set; }

    [SerializeField]
    private float attackDelay;

    private CinemachineFreeLook _cinemachine;

    private bool _canAttack = true;
    private float _oldVertical;
    private bool _oldIsRunning;

    private void Awake()
    {
        _cinemachine = FindObjectOfType<CinemachineFreeLook>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if(_oldVertical != Vertical && _canAttack)
        {
            StartCoroutine(DelayAttack(attackDelay/2));
        }
        _oldVertical = Vertical;

        if (!IsJoystickPluggedIn())
        {
            IsRunning = Input.GetKey(KeyCode.LeftShift);
            if (_oldIsRunning != IsRunning && _canAttack)
            {
                StartCoroutine(DelayAttack(0.2f));
            }
            _oldIsRunning = IsRunning;

            if (Vertical == 0 || Vertical !=0)
            {
                IsLightAttacking = Input.GetKeyDown(KeyCode.Mouse0) && _canAttack;
                IsHeavyAttacking = Input.GetKeyDown(KeyCode.Mouse1) && _canAttack;

                if (IsLightAttacking || IsHeavyAttacking)
                {
                    StartCoroutine(DelayAttack(attackDelay));
                }
            }
            
            _cinemachine.m_YAxis.m_InputAxisName = "Mouse ScrollWheel";
            _cinemachine.m_YAxis.m_MaxSpeed = 100;
        }
        else
        {
            IsRunning = Input.GetKey(KeyCode.Joystick1Button6);
            if (_oldIsRunning != IsRunning && _canAttack)
            {
                StartCoroutine(DelayAttack(0.2f));
            }
            _oldIsRunning = IsRunning;
            if (Vertical == 0 || Vertical != 0)
            {
                IsLightAttacking = Input.GetKeyDown(KeyCode.Joystick1Button0) && _canAttack;
                IsHeavyAttacking = Input.GetKeyDown(KeyCode.Joystick1Button1) && _canAttack;
                
                if (IsLightAttacking || IsHeavyAttacking)
                {
                    StartCoroutine(DelayAttack(attackDelay));
                }
            }
            
            _cinemachine.m_YAxis.m_InputAxisName = "Right Pad";
            _cinemachine.m_YAxis.m_MaxSpeed = 20;
        }
        // Cursor settings
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private bool IsJoystickPluggedIn()
    {
        String[] names = Input.GetJoystickNames();
        if (names.Length != 0)
           return true;
        else
           return false;
    }

    private IEnumerator DelayAttack(float delay)
    {
        _canAttack = false;
        yield return new WaitForSeconds(delay);
        _canAttack = true;
    }
}
