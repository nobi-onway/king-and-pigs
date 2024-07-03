using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController
{
    [SerializeField]
    private ListenInput _listenInput;
    [SerializeField]
    private Aiming _aiming;
    [SerializeField]
    private Firing _firing;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private HealthController _healthController;

    public MonoBehaviour MonoBehaviour => this;

    public event Action OnDead; 

    public void Init()
    {
        _healthController.Init();

        _listenInput.OnPointerUp += (Vector3) =>
        {
            _aiming.StopAiming();
            _firing.Fire();
            _animator.Play("attack");
        };

        _healthController.OnHealthChange += (currentHealth) =>
        {
            _animator.Play("got_hit");
            if (currentHealth == 0)
            {
                _healthController.IsEnabled = false;
                Dead();
            }
        };

        _listenInput.OnPointerDown += (Vector3) => { _aiming.StartAiming(); };
    }

    public void Reset()
    {
        _healthController.Init();
        OnDead = null;
    }

    private void Dead()
    {
        OnDead?.Invoke();
    }
}
