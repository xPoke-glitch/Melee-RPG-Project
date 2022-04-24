using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IStats
{
    public int Health { get; private set; }

    public int STR => 10;

    public static event Action OnDie;

    [SerializeField]
    private int maxHealth;

    public void Damage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
            OnDie?.Invoke();
    }

    public void Awake()
    {
        if (maxHealth <= 0)
            maxHealth = 1;
        Health = maxHealth;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
