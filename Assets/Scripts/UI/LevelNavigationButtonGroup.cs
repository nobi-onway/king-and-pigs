using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNavigationButtonGroup : MonoBehaviour
{
    [SerializeField] 
    private List<Button> _winNavigationButtons;
    [SerializeField]
    private List<Button> _loseNavigationButtons;

    private void Start()
    {
        LevelManager.Instance.OnStateChange += (state) =>
        {
            ShowNavigationIf(_winNavigationButtons, state == LevelState.winning);
            ShowNavigationIf(_loseNavigationButtons, state == LevelState.losing);
        };
    }

    private void ShowNavigationIf(List<Button> navigations, bool canShow)
    {
        navigations.ForEach(button => button.gameObject.SetActive(canShow));
    }
}
