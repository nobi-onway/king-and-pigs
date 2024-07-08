using UnityEngine;

public class ShowUIOnGameState : MonoBehaviour
{
    [SerializeField]
    private GameState _gameState;
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        GameManager.Instance.OnStateChange += (state) =>
        {
            ShowUIIf(state == _gameState);
        };
    }

    private void ShowUIIf(bool enabled)
    {
        if (_canvasGroup == null) return;
        _canvasGroup.alpha = enabled ? 1 : 0;
        _canvasGroup.interactable = enabled;
        _canvasGroup.blocksRaycasts = enabled;
    }
}
