using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private HealthController _healthController;

    private void Start()
    {
        _healthController.OnHealthChange += (currentHealth) => 
        {
            StartCoroutine(GotHit(currentHealth));
        };
    }

    private IEnumerator GotHit(int currentHealth)
    {
        _animator.Play("got_hit");

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        if (currentHealth <= 0) Dead();
    }

    private void Dead()
    {
        _animator.Play("dead");
        _healthController.IsEnabled = false;
    }
}
