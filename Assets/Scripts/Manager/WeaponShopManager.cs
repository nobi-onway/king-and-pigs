using System.Collections.Generic;
using UnityEngine;

public class WeaponShopManager : MonoBehaviour
{
    private List<WeaponSettings> _weaponList => GameResourceManager.Instance.GetWeaponSettingsList();
    private int _equipedWeaponId => PlayerPrefs.GetInt("equiped_weapon", _weaponList[0].Id);

    public WeaponSettings GetWeaponAtIndex(int index)
    {
        return _weaponList[index];
    }

    public int GetWeaponCount() => _weaponList.Count;

    public int GetEquipedWeaponIndex() => _weaponList.FindIndex(ws => ws.Id == _equipedWeaponId);

    public void EquipWeaponAtIndex(int index) => PlayerPrefs.SetInt("equiped_weapon", _weaponList[index].Id);

    public bool IsOwned(int index) => PlayerPrefs.GetInt(_weaponList[index].Id.ToString(), 0) == 1 ? true : false;

    public void BuyWeaponAtIndex(int index) => PlayerPrefs.SetInt(_weaponList[index].Id.ToString(), 1);
}
