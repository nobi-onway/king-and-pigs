using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private bool _isActive;
    public bool IsActive
    {
        get { return _isActive; }
        set 
        { 
            _isActive = value; 

            if(_isActive) Activate();
            if(!_isActive) StartCoroutine(DeActivate());
        }
    }

    private void Activate()
    {
        gameObject.SetActive(true);
        _animator.Play("idle");
    }

    private IEnumerator DeActivate()
    {
        _animator.Play("hit");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
        gameObject.SetActive(false);
    }
}
