using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottom_UI_WinLose : MonoBehaviour
{
    [SerializeField] private Button _btnBackMenu;
    [SerializeField] private Button _btnNextLevel;

    public void Init(bool isWin)
    {
        SettingWinLose(isWin);
        _btnNextLevel.onClick.AddListener(NextLevel);
    }
    private void NextLevel()
    {
        Debug.Log("NextLevel");
        LevelManager.Instance.State = LevelState.nextLevel;
    }
    private void SettingWinLose(bool isWin)
    {
        _btnNextLevel.gameObject.SetActive(isWin);
    }
    

}
