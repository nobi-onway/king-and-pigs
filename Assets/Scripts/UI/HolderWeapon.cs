using UnityEngine;
using UnityEngine.UI;

public class HolderWeapon : MonoBehaviour
{
    [SerializeField]
    private Text _name;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _attackValue;
    [SerializeField]
    private Text _bouncyValue;
    [SerializeField]
    private Text _description;

    public void Init(WeaponSettings weaponSettings)
    {
        _name.text = weaponSettings.Name;
        _image.sprite = weaponSettings.Image;
        _attackValue.text = weaponSettings.AttackValue.ToString();
        _bouncyValue.text = weaponSettings.BouncyValue.ToString();
        _description.text = $"Note: {weaponSettings.Description}";
    }
}
