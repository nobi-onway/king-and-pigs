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

    [SerializeField] 
    private WeaponController _weaponController;
    public MonoBehaviour MonoBehaviour => this;

    public event Action OnDead;

    private ControllerState _state;
    public ControllerState State 
    {
        get => _state;
        set
        {
            _state = value;
            OnStateChange?.Invoke(value);
        }
    }

    public event Action<ControllerState> OnStateChange;


    public void Init()
    {
        InitState();
        InitListenInput();
        InitHealth();
    }

    private void InitState()
    {
        OnStateChange += (state) =>
        {
            switch(state)
            {
                case ControllerState.idle:
                    break;
                case ControllerState.aiming:
                    Aim();
                    break;
                case ControllerState.firing:
                    Fire();
                    break;
                case ControllerState.dead:
                    Dead();
                    break;
                case ControllerState.winning:
                    _healthController.IsEnabled = false;
                    break;
            }
        };
    }

    private void Aim()
    {
        if (_firing.IsFiring) return;
        _aiming.StartAiming();
    }
    private void Fire()
    {
        if (_firing.IsFiring) return;

        _aiming.StopAiming();
        _firing.Fire(_weaponController);
        _animator.Play("attack");
    }

    private void InitHealth()
    {
        _healthController.Init();

        _healthController.OnHealthChange += (currentHealth) =>
        {
            _animator.Play("got_hit");
            if (currentHealth == 0) State = ControllerState.dead;
        };
    }

    private void InitListenInput()
    {
        _listenInput.OnPointerDown += () =>
        {
            State = ControllerState.aiming;
        };

        _listenInput.OnPointerUp += () =>
        {
            State = ControllerState.firing;
        };
    }

    public void Reset()
    {
        _healthController.Init();
        OnDead = null;
    }

    private void Dead()
    {
        _healthController.IsEnabled = false;
        OnDead?.Invoke();
    }
}