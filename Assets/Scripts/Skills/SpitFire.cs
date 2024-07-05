using UnityEngine;

public class SpitFire : MonoBehaviour
{
    [SerializeField]
    private GameObject _fire;
    [SerializeField]
    private int _numsOfFire;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpitFireCircle();
    }

    private void SpitFireCircle()
    {
        for(int i = 0; i < _numsOfFire; i++)
        {
            Quaternion rotation = Quaternion.Euler(Vector3.forward * 360/_numsOfFire * i);
            Spit(rotation);
        }
    }

    private void Spit(Quaternion rotation)
    {
        GameObject fireClone = Instantiate(_fire, transform.position, Quaternion.identity);
        fireClone.transform.rotation = rotation;
    }
}
