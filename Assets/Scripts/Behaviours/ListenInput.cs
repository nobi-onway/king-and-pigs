using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListenInput : MonoBehaviour
{
    public delegate void PointerAction(Vector3 position);
    public event PointerAction OnPointerDown;
    public event PointerAction OnPointerUp;
    public event PointerAction OnPointerDrag;

    private bool isDragging = false;

    private void Update()
    {
        if (IsPointerOverUIElement()) return;
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnPointerDown?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnPointerUp?.Invoke(Input.mousePosition);
        }
        if (isDragging)
        {
            OnPointerDrag?.Invoke(Input.mousePosition);
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
