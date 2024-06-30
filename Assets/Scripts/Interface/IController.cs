using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    public void Init();
    public MonoBehaviour MonoBehaviour { get; }
    public void Reset();
}
