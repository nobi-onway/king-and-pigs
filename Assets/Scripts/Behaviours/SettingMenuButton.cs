using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuButton : MonoBehaviour
{
    [Header("Space between menu items")]
    [SerializeField] Vector2 _spacing;

    private Button _mainButton;
    SettingMenuButtonItem[] _menuItems;
    bool isExpanded = false;

    Vector2 _mainButtonPosition;
    int _itemsCount;

    [Header("Canvas and Camera References")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private Camera uiCamera;
    [SerializeField] private RectTransform panelRectTransform;

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
            if (_menuItems[i] != null)
            {
                _menuItems[i]._trans.position = _mainButton.transform.position;
            }
        }
    }

    private void ToggleMenu()
    {
        isExpanded = !isExpanded;
        if (isExpanded)
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                if (_menuItems[i] != null)
                {
                    Vector2 targetPosition = _mainButton.GetComponent<RectTransform>().anchoredPosition + _spacing * (i + 1);
                    _menuItems[i]._trans.GetComponent<RectTransform>().anchoredPosition = targetPosition;
                }
            }
        }
        else
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                if (_menuItems[i] != null)
                {
                    _menuItems[i]._trans.position = _mainButton.transform.position;
                }
            }
        }
    }
    private Vector3 GetWorldPosition(Vector3 screenPosition)
    {
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera && uiCamera != null)
        {
            Vector2 viewportPosition = uiCamera.ScreenToViewportPoint(screenPosition);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.GetComponent<RectTransform>(), viewportPosition, uiCamera, out Vector3 worldPosition);
            return worldPosition;
        }
        else if (canvas.renderMode == RenderMode.WorldSpace)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.GetComponent<RectTransform>(), screenPosition, uiCamera, out Vector3 worldPosition);
            return worldPosition;
        }
        return screenPosition;
    }
    private void OnDestroy()
    {
        if (_mainButton != null)
        {
            _mainButton.onClick.RemoveListener(ToggleMenu);
        }
    }
}
