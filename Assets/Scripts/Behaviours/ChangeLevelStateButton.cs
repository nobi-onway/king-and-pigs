using UnityEngine;
using UnityEngine.UI;

public class ChangeLevelStateButton : MonoBehaviour
{
    [SerializeField]
    private LevelState _levelState;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => LevelManager.Instance.State = _levelState);
    }
}
