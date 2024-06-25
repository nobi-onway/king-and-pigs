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
        if (collision.gameObject.tag == "Enemy") StartCoroutine(Hit(collision));
        if (!collision.gameObject.CompareTag("Wall")) return;

        _currentBouncy++;

        if (_currentBouncy >= _maxInBouncy) Destroy(gameObject);
    }

    IEnumerator Hit(Collision2D collision)
    {
        collision.gameObject.GetComponentInChildren<Animator>().SetTrigger("got_hit_trig");
        yield return new WaitForSeconds(1);
        collision.gameObject.GetComponent<Heal>().OnTakeDamage(1);
    }
}
