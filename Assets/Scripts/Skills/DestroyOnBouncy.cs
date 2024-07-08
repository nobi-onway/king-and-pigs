using UnityEngine;

public class DestroyOnBouncy : MonoBehaviour
{
    public int MaxInBouncy;
    private int _currentBouncy;

    private void Start()
    {
        _currentBouncy = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall")) return;

        _currentBouncy++;

        if (_currentBouncy >= MaxInBouncy) Destroy(gameObject);
    }
}
