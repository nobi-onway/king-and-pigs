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
    private HealthController _healthController;

    private void Start()
    {
        _inputManager.OnPointerUp += () =>
        {
            _aiming.StopAiming();
            _firing.Fire();
            _animator.Play("attack");
        };

        _healthController.OnHealthChange += (currentHealth) =>
        {
            _animator.Play("got_hit");
        };

        _inputManager.OnPointerDown += () => { _aiming.StartAiming(); };
    }
}
