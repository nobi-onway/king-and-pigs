using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : MonoBehaviour
{
    [SerializeField] UIWinLosePanel _uiWinLosePanel;

    private void Start()
    {
        SetHideAllUI();

        LevelManager.Instance.OnStateChange += (state) =>
        {
            if (state == LevelState.winning) ShowUIWinLose(true);
            if (state == LevelState.losing) ShowUIWinLose(false);
        };
    }

    private void ShowUIWinLose(bool isWin)
    {
        _uiWinLosePanel.Init(isWin);
        _uiWinLosePanel.IsActive = true;
    }
    private void SetHideAllUI()
    {
        _uiWinLosePanel.IsActive = false;
    }
}
