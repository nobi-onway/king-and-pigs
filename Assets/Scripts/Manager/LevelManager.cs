using System;
using UnityEngine;

public class LevelManager : MonoBehaviour, IStateManager<LevelState>
{
    public static LevelManager Instance { get; private set; }

    private LevelController _currentLevelController;
    private int _currentLevel => 1;

    private LevelState _currentState;

    public event Action<LevelState> OnStateChange;

    public LevelState State 
    { 
        get => _currentState;
        set
        { 
            _currentState = value;
            OnStateChange?.Invoke(value);
        }
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;

        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        OnStateChange += (state) =>
        {
            switch (state)
            {
                case LevelState.playing:
                    LoadLevel();
                    break;
                case LevelState.losing:
                    // show losing panel
                    break;
                case LevelState.winning:
                    // show winning panel
                    break;
                case LevelState.nextLevel:
                    // current level ++
                    // change state to playing
                    break;
                default:
                    break;
            }
        };
    }

    private void LoadLevel() { }
}

public enum LevelState { playing, losing, winning, nextLevel }
