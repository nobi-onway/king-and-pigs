using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ReflectLaser : DestroyOnBouncy
{
    [Header("Settings")]
    [SerializeField]
    private LayerMask _layerMask;

    private LineRenderer _lineRenderer;

    public event Action<Collider2D> OnCollisionHit;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        Reflect();
    }

    private void Reflect()
    {
        Ray ray = new Ray(transform.position, transform.right);

        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, transform.position);

        for(int i = 0; i < MaxInBouncy; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, _layerMask);
            RaycastHit2D hitCollider = Physics2D.Raycast(ray.origin, ray.direction);

            OnCollisionHit?.Invoke(hitCollider.collider);

            if (hit)
            {
                _lineRenderer.positionCount++;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, hit.point);

                Vector2 threshold = ray.direction * 0.1f;

                ray = new Ray(hit.point - threshold, Vector2.Reflect(ray.direction.normalized, hit.normal.normalized));
            }
        }

        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        CurrentBouncy = MaxInBouncy;
    }
}
