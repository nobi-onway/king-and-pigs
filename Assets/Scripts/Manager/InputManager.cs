using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action OnPointerDown;
    public event Action OnPointerUp;

    private void Start()
    {
        OnPointerDown += () => Debug.Log("On Pointer Down");
        OnPointerUp += () => Debug.Log("On Pointer Up");
    }

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
