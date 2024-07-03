using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuButton : MonoBehaviour
{
    [Header("Space between menu items")]
    [SerializeField] Vector2 _spacing;

    private Button _mainButton;
    SettingMenuButtonItem[] _menuItems;
    bool isExpended = false;

    Vector2 _mainButtonPosition;
    int _itemsCount;
    void Start()
    {
        _itemsCount = transform.childCount - 1;
        _menuItems = new SettingMenuButtonItem[_itemsCount];
        for(int i = 0; i < _itemsCount; i++)
        {
            _menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingMenuButtonItem>();
        }

        _mainButton = transform.GetChild(0).GetComponent<Button>();
        _mainButton.onClick.AddListener(ToggleMenu);
        _mainButton.transform.SetAsLastSibling();

        _mainButtonPosition = _mainButton.transform.position;

        ResetPositions();

    }

    private void ResetPositions()
    {
        for(int i = 0; i < _itemsCount; i++)
        {
            _menuItems[i]._trans.position = _mainButtonPosition;
        }
    }

    private void ToggleMenu()
    {
        isExpended = !isExpended;
        if (isExpended)
        {
            Debug.Log("Open");
            for(int i = 0; i < _itemsCount; i++)
            {
                _menuItems[i]._trans.position = _mainButtonPosition + _spacing * (i + 1);
            }
        }
        else
        {
            Debug.Log("Cloes");
            for (int i = 0; i < _itemsCount; i++)
            {
                _menuItems[i]._trans.position = _mainButtonPosition;
            }
        }
    }
    private void OnDestroy()
    {
        _mainButton.onClick.RemoveListener(ToggleMenu);
    }
}
