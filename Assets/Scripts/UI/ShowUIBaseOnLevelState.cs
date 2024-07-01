using UnityEngine;

public class ShowUIBaseOnLevelState : MonoBehaviour
{
    [SerializeField] private LevelState _levelState;

    private void Start()
    {
        LevelManager.Instance.OnStateChange += (state) =>
        {
            gameObject.SetActive(state == _levelState);
        };
    }
}
