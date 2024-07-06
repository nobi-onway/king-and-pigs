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

    [SerializeField]
    private WeaponSettings _weaponSettings;

    private void Start()
    {
        _name.text = _weaponSettings.Name;
        _image.sprite = _weaponSettings.Image;
        _attackValue.text = _weaponSettings.AttackValue.ToString();
        _bouncyValue.text = _weaponSettings.BouncyValue.ToString();
        _description.text = $"Note: {_weaponSettings.Description}";
    }
}
