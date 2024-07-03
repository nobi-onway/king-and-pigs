using System;
using UnityEngine;

public class ListenInput : MonoBehaviour
{
    public event Action OnPointerDown;
    public event Action OnPointerUp;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnPointerDown?.Invoke();
        }

        if(Input.GetMouseButtonUp(0))
        {
            OnPointerUp?.Invoke();
        }
    }
}
