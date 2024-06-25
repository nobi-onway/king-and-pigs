using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private Transform FirePosition;

    [SerializeField] private float _minAngleZ;
    [SerializeField] private float _maxAngleZ;
    [SerializeField] private float _speedRotate;
    private bool _isAimingUp = true;
    
    private Coroutine _rotationCoroutine;

    public void StartAiming()
    {
        ResetRotation();
        _rotationCoroutine = StartCoroutine(RotateCoroutine());
    }

    public void StopAiming()
    {
        StopCoroutine(_rotationCoroutine);
        FirePosition.gameObject.SetActive(false);
    }

    private void ResetRotation() 
    {
        FirePosition.rotation = Quaternion.identity;
        _isAimingUp = true;
    }


    IEnumerator RotateCoroutine()
    {
        FirePosition.gameObject.SetActive(true);       
        while (true)
        {
            int direc = _isAimingUp ? 1 : -1; 
            FirePosition.Rotate(0, 0, _speedRotate  * Time.deltaTime * direc);
            if (FirePosition.rotation.eulerAngles.z >= _maxAngleZ && _isAimingUp) _isAimingUp = false;
            else if (FirePosition.rotation.eulerAngles.z <= _minAngleZ) _isAimingUp = true;
            
            yield return new WaitForEndOfFrame();
        }
        
    }

}
