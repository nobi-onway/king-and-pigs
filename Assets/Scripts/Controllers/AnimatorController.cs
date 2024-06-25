using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public void TriggerAnimation(string name) => _animator.SetTrigger(name);
}
