using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField]
    private float _rorateSpeed;

    private void Update()
    {
        transform.Rotate(0, 0, _rorateSpeed);
    }
}
