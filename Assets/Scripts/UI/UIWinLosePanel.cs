using UnityEngine;

public class UIWinLosePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        LevelManager.Instance.OnStateChange += (state) =>
        {
            EnableUIIf(state == LevelState.winning || state == LevelState.losing);
        };
    }

    private void EnableUIIf(bool enabled)
    {
        _canvasGroup.alpha = enabled ? 1  : 0;
        _canvasGroup.interactable = enabled;
        _canvasGroup.blocksRaycasts = enabled;
    }
}
