using UnityEngine;
using UnityEngine.UI;

public class ChangeGameStateButton : MonoBehaviour
{
    [SerializeField]
    private GameState _gameStateToChange;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => GameManager.Instance.State = _gameStateToChange);
    }
}
