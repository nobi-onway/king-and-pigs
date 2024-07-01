using UnityEngine;
using UnityEngine.UI;

public class MiddleUIWinLose : MonoBehaviour
{
    [SerializeField] private Image _imgShowStateGame;

    [SerializeField] private Sprite _imgWinGame;
    [SerializeField] private Sprite _imgLoseGame;

    
    public void Init(bool isWin)
    {
        _imgShowStateGame.sprite = isWin ? _imgWinGame : _imgLoseGame;
    }
}
