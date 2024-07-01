using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomUIWinLose : MonoBehaviour
{
    [SerializeField] private Button _btnBackMenu;
    [SerializeField] private Button _btnNextLevel;

    private void Start()
    {
        _btnNextLevel.onClick.AddListener(NextLevel);
    }
    public void Init(bool isWin)
    {
        SettingWinLose(isWin);
    }
    private void NextLevel()
    {
        LevelManager.Instance.State = LevelState.nextLevel;
    }
    private void SettingWinLose(bool isWin)
    {
        _btnNextLevel.gameObject.SetActive(isWin);
    }
}
