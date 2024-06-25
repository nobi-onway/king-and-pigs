using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField]
    private GameObject _fireObject;
    [SerializeField]
    private Transform _firePosition;
    public void Fire()
    {
        Instantiate(_fireObject, _firePosition.position, _firePosition.rotation);
    }
}
