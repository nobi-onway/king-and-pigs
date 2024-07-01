using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWinLosePanel : MonoBehaviour
{
    private bool _isActive;
    public bool IsActive { get=> _isActive; set { _isActive = value; gameObject.SetActive(_isActive); } }

    [SerializeField] private MiddleUIWinLose _middle_WinLose;
    [SerializeField] private BottomUIWinLose _bottom_WinLose;


    public void Init(bool isWin)
    {
        _middle_WinLose.Init(isWin);
        _bottom_WinLose.Init(isWin);
    }

}
