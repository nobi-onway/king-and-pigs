using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePosition : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField] 
    private GameObject _quaterCircle;

    private bool _isActive;
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;

            _quaterCircle.SetActive(_isActive);
            _lineRenderer.enabled = _isActive;
        }
    }

    private void Start()
    {
        IsActive = false;
    }
}
