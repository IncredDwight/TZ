using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(IDie))]
public class Health : MonoBehaviour
{
    public Action<float> OnTakenDamage;

    [SerializeField] private float _maxHealth;
    private float _health;

    private IDie _death;

    private void Awake()
    {
        _health = _maxHealth;
        _death = GetComponent<IDie>();
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        OnTakenDamage?.Invoke(_health / _maxHealth);
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        _death.Die();
    }
}
