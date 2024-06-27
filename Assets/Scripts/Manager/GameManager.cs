using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IStateManager<GameState>
{
    public static GameManager Instance { get; private set; }

    private GameState _state;
    public GameState State
    {
        get { return _state; }
        set { _state = value; OnStateChange?.Invoke(value); }
    }

    public event Action<GameState> OnStateChange;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        OnStateChange += (state) =>
        {
            switch (state)
            {
                case GameState.menu:
                    SceneManager.LoadScene("MenuScene");
                    break;
                case GameState.gaming:
                    SceneManager.LoadScene("GameScene");
                    break;
                case GameState.shopping:

                    break;
                case GameState.setting:

                    break;
                default:
                    break;
            }
        };
    }
}

public enum GameState { menu, gaming, shopping, setting }
