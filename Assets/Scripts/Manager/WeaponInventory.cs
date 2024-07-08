using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    private int _equipedWeaponId => PlayerPrefs.GetInt("equiped_weapon");
    public WeaponController GetEquipedWeaponController()
    {
        WeaponSettings weaponSettings = GameResourceManager.Instance.GetWeaponSettingsList().Find(ws => ws.Id == _equipedWeaponId);
        WeaponController weaponController = weaponSettings.Controller;
        weaponController.Init(weaponSettings);

        return weaponController;
    }
    
}
