using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    public event Action<int> OnHealthChange;
    public bool IsEnabled { get; set; }
    public int CurrentHealth
    { 
        get { return _currentHealth; } 
        set 
        {
            if (!IsEnabled) return;
            _currentHealth = value < 0 ? 0 : value; 
            OnHealthChange(value);
        } 
    }

    public void Init()
    {
        _currentHealth = _maxHealth;
        IsEnabled = true;
    }
}
