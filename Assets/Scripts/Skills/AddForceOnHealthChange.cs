using UnityEngine;

public class AddForceOnHealthChange : MonoBehaviour
{
    [SerializeField]
    private Vector2 _direction;
    [SerializeField]
    private HealthController _healthController;
    [SerializeField]
    private Rigidbody2D _rb2D;
    [SerializeField]
    private float _force;

    private void Start()
    {
        _healthController.OnHealthChange += (currentHealth) =>
        {
            _rb2D.AddForce(_direction * _force, ForceMode2D.Impulse);
        };
    }

}
