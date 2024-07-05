using UnityEngine;
using UnityEngine.UI;

public class UIWinLosePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private Text _title;
    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        LevelManager.Instance.OnStateChange += (state) =>
        {
            EnableUIIf(state == LevelState.winning || state == LevelState.losing);
            _title.text = state == LevelState.winning ? "Victory" : state == LevelState.losing ? "Game Over" : "";
        };
    }

    private void EnableUIIf(bool enabled)
    {
        _canvasGroup.alpha = enabled ? 1  : 0;
        _canvasGroup.interactable = enabled;
        _canvasGroup.blocksRaycasts = enabled;
    }
}
