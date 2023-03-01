using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    private float _minHealth = 0f;
    private float _maxHealth = 1f;
    private float _currenthealth;

    public event UnityAction<float> HealthChanged;
    public float Health => _maxHealth;

    private void Start()
    {
        _currenthealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currenthealth -= damage;

        if(_currenthealth < _minHealth)
        {
            _currenthealth = _minHealth;
        }

        HealthChanged?.Invoke(CurrentHealth);
    }

    public void TakeHeal(float heal)
    {
        _currenthealth += heal;

        if (_currenthealth > _maxHealth)
        {
            _currenthealth = _maxHealth;
        }

        HealthChanged?.Invoke(CurrentHealth);
    }

    public float CurrentHealth
    {
        get { return _currenthealth; }
        set { _currenthealth = Mathf.Clamp(value, _minHealth, _maxHealth); }                
    }
}
