using UnityEngine;

public class CauseDamageOnTouch : MonoBehaviour
{
    [SerializeField]
    private int _damage;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthController healthController = collision.gameObject.GetComponent<HealthController>();
        if (!healthController) return;
        if (!healthController.IsEnabled) return;

        healthController.CurrentHealth -= _damage;
    }
}
