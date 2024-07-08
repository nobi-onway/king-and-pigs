using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public event Action OnWeaponDestroy;

    [SerializeField]
    private DestroyOnBouncy _destroyOnBouncy;
    [SerializeField]
    private BaseAttackSkill _baseAttackSkill;
    public void Init(WeaponSettings settings)
    {
        _destroyOnBouncy.MaxInBouncy = (settings.BouncyValue);
        _baseAttackSkill.Damage = settings.AttackValue;
    }
    private void OnDestroy()
    {
        OnWeaponDestroy?.Invoke();
    }
}
