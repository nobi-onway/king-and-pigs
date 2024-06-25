using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] int _currentHeal;
    [SerializeField] int _maxHeal;

    private void Start()
    {
        _currentHeal = _maxHeal;
    }
    public void OnTakeDamage(int amount)
    {
        _currentHeal -= amount;
        Debug.Log("Hit");
        if (_currentHeal == 0)
        {
            Debug.Log("Dead");
            //Destroy(gameObject);
        }
    }
}
