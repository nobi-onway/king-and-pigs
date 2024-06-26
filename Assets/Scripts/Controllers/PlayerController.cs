using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;

    [SerializeField]
    private Aiming _aiming;
    [SerializeField]
    private Firing _firing;
    [SerializeField]
    private Animator _animator;
    [SerializeField]

    private void Start()
    {
        _inputManager.OnPointerUp += () =>
        {
            _aiming.StopAiming();
            _firing.Fire();
            _animator.SetTrigger("attack_trig");
        };

        _inputManager.OnPointerDown += () => { _aiming.StartAiming(); };
    }
}
