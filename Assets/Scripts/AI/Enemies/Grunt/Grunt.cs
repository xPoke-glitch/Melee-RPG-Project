using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour, IDamageable, IStats
{
    public int Health { get; private set; }

    public int STR => 5;

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
            Die();
        }
    }

    void Awake()
    {
        if (maxHealth <= 0)
            maxHealth = 1;
        Health = maxHealth;
    }

    void Update()
    {

    }

    public void Die()
    {
        Destroy(this.gameObject, 1.5f);
    }

}
