using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBouncy : MonoBehaviour
{
    [SerializeField]
    private int _maxInBouncy;
    private int _currentBouncy;

    private void Start()
    {
        _currentBouncy = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall")) return;

        _currentBouncy++;

        if (_currentBouncy >= _maxInBouncy) Destroy(gameObject);
    }
}
