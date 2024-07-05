using System;
using UnityEngine;

public interface IController
{
    public void Init();
    public MonoBehaviour MonoBehaviour { get; }
    public void Reset();
}

public enum ControllerState { idle, aiming, firing, dead, winning, losing }
