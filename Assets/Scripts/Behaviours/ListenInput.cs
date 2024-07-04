using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListenInput : MonoBehaviour
{
    public event Action OnPointerDown;
    public event Action OnPointerUp;

    private void Update()
    {
        if (IsPointerOverUIElement()) return;

        if (Input.GetMouseButtonDown(0))
        {
            OnPointerDown?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnPointerUp?.Invoke();
        }
    }

    private bool IsPointerOverUIElement()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}
