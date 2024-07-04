using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public event Action OnWeaponDestroy;

    private void OnDestroy()
    {
        OnWeaponDestroy?.Invoke();
    }
}
