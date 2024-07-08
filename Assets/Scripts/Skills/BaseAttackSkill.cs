using System;
using UnityEngine;

public abstract class BaseAttackSkill : MonoBehaviour
{
    public int Damage;

    protected virtual void TakeDamgeOn(Collider2D collider, Action callback = null)
    {
        HealthController healthController = collider.GetComponent<HealthController>();
        if (!healthController) return;
        if (!healthController.IsEnabled) return;

        healthController.CurrentHealth -= Damage;

        if (callback == null) return;
        callback();
    }
}
