using UnityEngine;

public class CauseDamageOnTouch : BaseAttackSkill
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamgeOn(collision.collider, () => Destroy(gameObject));
    }
}
