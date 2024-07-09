using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IController
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private HealthController _healthController;

    public event Action OnDead;
    public bool IsDead { get; private set; }

    public MonoBehaviour MonoBehaviour => this;

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
        InitHeart();
        InitState();
        State = ControllerState.idle;
    }
    public void InitHeart()
    {
        _healthController.Init();

        _healthController.OnHealthChange += (currentHealth) =>
        {
            StartCoroutine(GotHit(currentHealth));
            if (currentHealth == 0) State = ControllerState.dead;
        };
    }
    private void InitState()
    {
        OnStateChange += (state) =>
        {
            switch (state)
            {
                case ControllerState.idle:
                    Idle();
                    break;
                case ControllerState.running:
                    Running();
                    break;
                case ControllerState.dead:
                    break;
                case ControllerState.winning:
                    _healthController.IsEnabled = false;
                    break;
                default:break;
            }
        };
    }

    public void Reset()
    {
        _healthController.Init();
        IsDead = false;
        OnDead = null;
    }

    private IEnumerator GotHit(int currentHealth)
    {
        _animator.Play("got_hit");

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        if (currentHealth <= 0) Dead();
    }
    private void Idle()
    {
        _animator.Play("Idle");
    }
    private void Running()
    {
        _animator.Play("run");
    }
    private IEnumerator Dead()
    {
        _animator.Play("dead");
        _healthController.IsEnabled = false;
        IsDead = true;
        OnDead?.Invoke();
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
