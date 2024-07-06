using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private int _timePatrolEnd = 5;
    [SerializeField] private int _timePatrolStart = 3;
    [SerializeField] private Rigidbody2D _characterRb;
    [SerializeField] private EnemyController _enemyController;
    private bool isRunning = false;


    private void Start()
    {
        _enemyController.OnStateChange += (state) =>
        {
            if(state == ControllerState.running)
            {
                StartCoroutine(EndPatrol());
            }
            if(state == ControllerState.dead)
            {
                isRunning = false;
                StopAllCoroutines();
            }
            if (state == ControllerState.idle)
            {
                StartCoroutine(StartPatrol());
            }
        };
        _enemyController.State = ControllerState.running;
    }
    private void Update()
    {
        if (!isRunning) return;
        OnPatrol();
    }

    IEnumerator  EndPatrol()
    {
        isRunning = true;
        yield return new WaitForSecondsRealtime(_timePatrolEnd);
        isRunning = false;             
        _enemyController.State = ControllerState.idle;

    }
    IEnumerator StartPatrol()
    {
        yield return new WaitForSecondsRealtime(_timePatrolStart);
        _enemyController.State = ControllerState.running;
    }

    public void OnPatrol()
    {        
        float speed = IsFacingLeft() ? -_moveSpeed : _moveSpeed;
        _characterRb.velocity = new Vector2(speed, 0);
      
    }
    private bool IsFacingLeft()
    {
        return _characterRb.transform.localScale.x > 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _characterRb.transform.localScale = new Vector2(-(Mathf.Sign(_characterRb.transform.localScale.x)), _characterRb.transform.localScale.y);
    }
}
