using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private FirePosition _firePosition;

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
        _firePosition.IsActive = false;
    }

    private void ResetRotation() 
    {
        Vector3 fireEulerAngles = _firePosition.transform.eulerAngles;
        _firePosition.transform.rotation = Quaternion.Euler(fireEulerAngles.x, fireEulerAngles.y, _minAngleZ);
        _isAimingUp = true;
    }


    IEnumerator RotateCoroutine()
    {
        _firePosition.IsActive = true;       

        while (true)
        {
            int direc = _isAimingUp ? 1 : -1; 
            _firePosition.transform.Rotate(0, 0, _speedRotate  * Time.deltaTime * direc);
            if (_firePosition.transform.rotation.eulerAngles.z >= _maxAngleZ && _isAimingUp) _isAimingUp = false;
            else if (_firePosition.transform.rotation.eulerAngles.z <= _minAngleZ) _isAimingUp = true;
            
            yield return new WaitForEndOfFrame();
        }
        
    }

}
