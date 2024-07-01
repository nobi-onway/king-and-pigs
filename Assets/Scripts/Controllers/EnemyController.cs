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

    public void Init()
    {
        _healthController.Init();

        _healthController.OnHealthChange += (currentHealth) =>
        {
            StartCoroutine(GotHit(currentHealth));
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

    private void Dead()
    {
        _animator.Play("dead");
        _healthController.IsEnabled = false;
        IsDead = true;
        Debug.Log("Dead");
        OnDead?.Invoke();
    }

}
