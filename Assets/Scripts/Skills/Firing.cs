using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField]
    private Transform _firePosition;
    public bool IsFiring = false;
    public void Fire(WeaponController weapon)
    {
        IsFiring = true;
        GameObject weaponClone = Instantiate(weapon.gameObject, _firePosition.position, _firePosition.rotation);
        weaponClone.GetComponent<WeaponController>().OnWeaponDestroy += () => { IsFiring = false; };
    }
}
