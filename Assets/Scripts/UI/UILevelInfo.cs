using UnityEngine;
using UnityEngine.UI;

public class UILevelInfo : MonoBehaviour
{
    [SerializeField]
    private Text _numsOfAttack;
    [SerializeField]
    private Text _health;
    [SerializeField]
    private Text _feedback;

    public void UpdateUI(int attackCount, int health)
    {
        _numsOfAttack.text = attackCount.ToString();
        _health.text = health.ToString();

        _feedback.text = GetFeedback(health);
    }

    private string GetFeedback(int health)
    {
        if (health < 1) return "Nice Try";
        else if (health < 2) return "Good Attack";
        else return "Super Attack Turn";
    }
}
