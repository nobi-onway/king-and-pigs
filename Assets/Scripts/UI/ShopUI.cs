using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private HolderWeapon _holderWeapon;
    [SerializeField]
    private Transform _holderWeaponList;
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Button _previousButton;
    [SerializeField]
    private Button _equipButton;
    [SerializeField]
    private Button _buyButton;

    private WeaponShopManager _weaponShopManager;
    private int _currentIndex;
    public int CurrentIndex
    {
        get => _currentIndex;
        private set 
        {
            _currentIndex = value;

            EnableButton(_nextButton, _currentIndex < _weaponShopManager.GetWeaponCount() - 1);
            EnableButton(_previousButton, _currentIndex > 0);
            EnableButton(_equipButton, _currentIndex != _weaponShopManager.GetEquipedWeaponIndex());
            _holderWeapon.Init(_weaponShopManager.GetWeaponAtIndex(_currentIndex));

            ActivateButton(_equipButton, _weaponShopManager.IsOwned(_currentIndex));
            ActivateButton(_buyButton, !_weaponShopManager.IsOwned(_currentIndex));
        }
    }

    private void Start()
    {
        _weaponShopManager = GetComponent<WeaponShopManager>();
        _nextButton.onClick.AddListener(() => CurrentIndex++);
        _previousButton.onClick.AddListener(() => CurrentIndex--);

        _equipButton.onClick.AddListener(Equip);

        _buyButton.onClick.AddListener(() =>
        {
            Buy();
            Equip();
        });

        CurrentIndex = 0;
    }

    private void Equip()
    {
        _weaponShopManager.EquipWeaponAtIndex(_currentIndex);
        EnableButton(_equipButton, false);
    }

    private void Buy()
    {
        _weaponShopManager.BuyWeaponAtIndex(_currentIndex);
        ActivateButton(_equipButton, _weaponShopManager.IsOwned(_currentIndex));
        ActivateButton(_buyButton, !_weaponShopManager.IsOwned(_currentIndex));
    }

    private void ActivateButton(Button button, bool active)
    {
        button.gameObject.SetActive(active);
    }

    private void EnableButton(Button button, bool enabled)
    {
        CanvasGroup canvasGroup = button.GetComponent<CanvasGroup>();

        canvasGroup.interactable = enabled;
        canvasGroup.alpha = enabled ? 1 : 0.2f;
        canvasGroup.blocksRaycasts = enabled;
    }
}
