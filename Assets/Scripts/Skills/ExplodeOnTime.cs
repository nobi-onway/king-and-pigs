using System.Collections;
using UnityEngine;

public class ExplodeOnTime : MonoBehaviour
{
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _radius;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private Animator _animator;

    private Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(ExplodeOn(_timer));
    }

    private IEnumerator ExplodeOn(float time)
    {
        yield return new WaitForSeconds(time);

        Explode();
    }

    private void Explode()
    {
        transform.localScale = Vector2.one * _radius;
        _rb2D.velocity = Vector2.zero;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            TakeDamgeOn(colliders[i]);
        }

        _animator.Play("explode");
        StartCoroutine(DestroyAfter(_animator.GetCurrentAnimatorClipInfo(0).Length));
    }

    private IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void TakeDamgeOn(Collider2D collider)
    {
        HealthController healthController = collider.GetComponent<HealthController>();
        if (!healthController) return;
        if (!healthController.IsEnabled) return;

        healthController.CurrentHealth -= _damage;
    }
}
