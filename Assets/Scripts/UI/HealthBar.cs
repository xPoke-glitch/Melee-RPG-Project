using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image border;
    [SerializeField]
    private Image fill;
    [SerializeField]
    private Gradient gradient;

    private Slider _slider;
    private IDamageable _damageableEntity;

    void Awake()
    {
        _slider = GetComponent<Slider>();
        _damageableEntity = GetComponentInParent<IDamageable>();
    }

    void Start()
    {
        SetMaxHealth(_damageableEntity.Health);
    }

    void Update()
    {
        SetHealth(_damageableEntity.Health);
    }

    private void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;

        fill.color = gradient.Evaluate(1f);

        HideHealthBar();
    }

    private void SetHealth(int health)
    {
        if(_slider.value != health)
        {
            ShowHealthBar();
        }
        _slider.value = health;
        fill.color = gradient.Evaluate(_slider.normalizedValue);

        if(_slider.value == _slider.maxValue)
        {
            HideHealthBar();
        }
    }

    private void HideHealthBar()
    {
        border.enabled = false;
        fill.enabled = false;
    }

    private void ShowHealthBar()
    {
        border.enabled = true;
        fill.enabled = true;
    }
}
