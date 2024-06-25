using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    public event Action<int> OnHealthChange;
    public bool IsEnabled { get; set; }
    public int CurrentHealth
    { get { return _currentHealth; } set { _currentHealth = value; OnHealthChange(value); } }

    private void Start()
    {
        _currentHealth = _maxHealth;
        IsEnabled = true;
    }
}
