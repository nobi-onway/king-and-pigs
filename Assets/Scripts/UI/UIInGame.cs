using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : MonoBehaviour
{
    #region SingleTon
    public static UIInGame Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) Instance = this;

        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion

    [SerializeField] UIWinLosePanel _uiWinLosePanel;


    private void Start()
    {
        SetHideAllUI();
        
    }

    private void InitUI()
    {

    }
    public void ShowUIWinLose(bool isWin)
    {
        _uiWinLosePanel.Init(isWin);
        _uiWinLosePanel.IsActive = true;
    }
    private void SetHideAllUI()
    {
        _uiWinLosePanel.IsActive = false;
    }

    
}
