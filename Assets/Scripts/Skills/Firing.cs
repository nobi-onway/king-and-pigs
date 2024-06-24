using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField]
    private GameObject _fireObject;
    [SerializeField]
    private Transform _firePosition;

    public InputManager _inputManager;

    private void Start()
    {
        _inputManager.OnPointerUp += Fire;
    }

    private void Fire()
    {
        Instantiate(_fireObject, _firePosition.position, _firePosition.rotation);
    }
}
