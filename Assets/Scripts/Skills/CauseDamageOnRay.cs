using UnityEngine;

public class CauseDamageOnRay : BaseAttackSkill
{
    [SerializeField]
    private ReflectLaser _reflectLaser;

    private void OnEnable()
    {
        _reflectLaser.OnCollisionHit += (collider2D) =>
        {
            TakeDamgeOn(collider2D);
        };
    }
}
