using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInSideDoor : MonoBehaviour
{
    [SerializeField] Animator _animDoor;
    [SerializeField] GameObject _spriteControl;
    [SerializeField] EnemyController _enemyController;
    int _timeStartHide = 6;
    int _timeEndHide = 3;
    bool isHideInsideDoor = false;


    private void Start()
    {
        _enemyController.OnStateChange += (state) =>
        {
            switch (state)
            {
                case ControllerState.idle:
                    IdleDoor();
                    break;
                case ControllerState.hide:
                    HideEnemy();
                    break;
                case ControllerState.show:                    
                    ShowEnemy();
                    break;
                case ControllerState.dead:
                    StopAllCoroutines();
                    break;
                default: break;
            }
        };
        _enemyController.State = ControllerState.hide;
    }

    private void IdleDoor()
    {
        _animDoor.Play("Idle");                
    }
    private void HideEnemy()
    {
        isHideInsideDoor = false;
        StartCoroutine(Show());        
    }
    private void ShowEnemy()
    {
        isHideInsideDoor = true;
        StartCoroutine(Show());        
    }
    
    IEnumerator TimeStartHide()
    {
        yield return new WaitForSeconds(_timeStartHide);
        _enemyController.State = ControllerState.hide;
    }
    IEnumerator TimeEndHide()
    {
        yield return new WaitForSeconds(_timeEndHide);
        _enemyController.State = ControllerState.show;
    }

    IEnumerator Show()
    {
        _animDoor.Play("Opening");
        yield return new WaitForSeconds(_animDoor.GetCurrentAnimatorStateInfo(0).length);
        _spriteControl.SetActive(isHideInsideDoor);
        _enemyController.IsActiveObj = isHideInsideDoor;
        _animDoor.Play("closing");
        yield return new WaitForSeconds(_animDoor.GetCurrentAnimatorStateInfo(0).length);
        _enemyController.State = ControllerState.idle;        
        if(isHideInsideDoor== false) StartCoroutine(TimeEndHide());
        else StartCoroutine(TimeStartHide());
    }
    
}
