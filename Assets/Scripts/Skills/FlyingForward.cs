using UnityEngine;

public class FlyingForward : MonoBehaviour
{
    [SerializeField]
    private float _velocity;
    private Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        MoveForward();
    }

    private void MoveForward()
    {
        _rb2D.velocity = transform.right * _velocity;
    }
}
