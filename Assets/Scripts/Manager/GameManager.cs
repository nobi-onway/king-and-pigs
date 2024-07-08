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
                    LoadScene("MenuScene");
                    break;
                case GameState.gaming:
                    LoadScene("GameScene");
                    break;
                case GameState.shopping:
                    Debug.Log("Shopping");
                    break;
                case GameState.setting:

                    break;
                default:
                    break;
            }
        };
    }

    private void LoadScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == sceneName) return;
        SceneManager.LoadScene(sceneName);
    }
}

public enum GameState { menu, gaming, shopping, setting }
