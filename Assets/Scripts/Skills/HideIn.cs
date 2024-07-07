using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIn : MonoBehaviour
{
    [SerializeField] Animator _animHidePlace;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] HealthController _healthController;
    [SerializeField] BoxCollider2D _boxCollider2D;

    int _timeStartHide = 6;
    int _timeEndHide = 3;

    private bool _isHide;
    public bool IsHide
    {
        get => _isHide;
        private set
        {
            _isHide = value;

            StartCoroutine(HideIf(_isHide));
        }
    }

    private void Start()
    {
        StartCoroutine(InfinityHide());
    }

    private IEnumerator InfinityHide()
    {
        while(true)
        {
            yield return new WaitForSeconds(_timeStartHide);
            IsHide = true;
            yield return new WaitForSeconds(_timeEndHide);
            IsHide = false;
        }
    }

    private IEnumerator HideIf(bool canHide)
    {
        _animHidePlace.Play("Opening");
        yield return new WaitForSeconds(_animHidePlace.GetCurrentAnimatorStateInfo(0).length);
        _spriteRenderer.enabled = canHide;
        _healthController.IsEnabled = canHide;
        _boxCollider2D.enabled = canHide;
        _animHidePlace.Play("closing");
        yield return new WaitForSeconds(_animHidePlace.GetCurrentAnimatorStateInfo(0).length);
    }
}
