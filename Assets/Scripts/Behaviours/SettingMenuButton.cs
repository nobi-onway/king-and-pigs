using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuButton : MonoBehaviour
{
    [Header("Space between menu items")]
    [SerializeField] Vector2 _spacing;

    [SerializeField] private Button _mainButton;
    [SerializeField] private Button[] _menuItems;

    private bool isExpanded = false;

    void Start()
    {
        _mainButton.onClick.AddListener(ToggleMenu);
        _mainButton.transform.SetAsLastSibling();

        SetMenuItemPosition(_menuItems, _mainButton, Vector2.zero);
    }

    private void ToggleMenu()
    {
        isExpanded = !isExpanded;
        Vector2 spacing = isExpanded ? _spacing : Vector2.zero;

        SetMenuItemPosition(_menuItems, _mainButton, spacing);
    }

    private void SetMenuItemPosition(Button[] settingMenuButtonList, Button mainButton, Vector2 spacing)
    {
        for (int i = 0; i < settingMenuButtonList.Length; i++)
        {
            if (settingMenuButtonList[i] == null) return;
            
            Vector2 targetPosition = mainButton.GetComponent<RectTransform>().anchoredPosition + spacing * (i + 1);
            settingMenuButtonList[i].transform.GetComponent<RectTransform>().anchoredPosition = targetPosition;
        }
    }
   
    private void OnDestroy()
    {
        if (_mainButton != null)
        {
            _mainButton.onClick.RemoveListener(ToggleMenu);
        }
    }
}
