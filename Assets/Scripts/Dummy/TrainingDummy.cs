using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour, IDamageable
{
    public int Health { get; private set; }
    public event Action OnDie;
    public event Action OnDamage;

    [SerializeField]
    private int maxHealth;

    public void Damage(int amount)
    {
        Health -= amount;
        OnDamage?.Invoke();

        if (Health <= 0)
        {
            OnDie?.Invoke();
            ResetDummy();
        }
    }

    void Awake()
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

    public void ResetDummy()
    {
        Health = maxHealth;
    }
}
