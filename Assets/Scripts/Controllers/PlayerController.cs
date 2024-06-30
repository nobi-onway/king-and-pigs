using UnityEngine;

public class PlayerController : MonoBehaviour, IController
{
    [SerializeField]
    private ListenInput _listenInput;
    [SerializeField]
    private Aiming _aiming;
    [SerializeField]
    private Firing _firing;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private HealthController _healthController;

    public MonoBehaviour MonoBehaviour => this;

    public void Init()
    {
        _healthController.Init();

        _listenInput.OnPointerUp += () =>
        {
            _aiming.StopAiming();
            _firing.Fire();
            _animator.Play("attack");
        };

        _healthController.OnHealthChange += (currentHealth) =>
        {
            _animator.Play("got_hit");
            if (currentHealth == 0) 
            {
                _healthController.IsEnabled = false;
                LevelManager.Instance.CheckMapWinLose(); 
            }
        };

        _listenInput.OnPointerDown += () => { _aiming.StartAiming(); };
    }

    public void Reset()
    {
        _healthController.Init();
    }
}
