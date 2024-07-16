using UnityEngine;

public class DestroyOnBouncy : MonoBehaviour
{
    public int MaxInBouncy;
    private int _currentBouncy;
    public int CurrentBouncy
    {
        get { return _currentBouncy; }
        set
        {
            _currentBouncy = value;
            if (_currentBouncy >= MaxInBouncy) Destroy(gameObject);
        }
    }

    private void Start()
    {
        CurrentBouncy = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall")) return;

        CurrentBouncy++;
    }
}
