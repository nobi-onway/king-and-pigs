using System;
using UnityEngine;

public class LevelManager : MonoBehaviour, IStateManager<LevelState>
{
    public static LevelManager Instance { get; private set; }

    [SerializeField]
    private LevelController _levelController;
    [SerializeField]
    private HealthBarController _healthBarController;
    [SerializeField]
    private UILevelInfo _uiLevelInfo;
    private int _currentLevel => PlayerPrefs.GetInt("current_level", 1);

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
        SetUpLevelController();

        OnStateChange += (state) =>
        {
            switch (state)
            {
                case LevelState.playing:
                    LoadLevel();
                    break;
                case LevelState.losing:
                    Debug.Log("Losing");
                    _uiLevelInfo.UpdateUI(GetPlayerAttackCount(), GetPlayerCurrentHealth());
                    break;
                case LevelState.winning:
                    Debug.Log("Winning");
                    _uiLevelInfo.UpdateUI(GetPlayerAttackCount(), GetPlayerCurrentHealth());
                    break;
                case LevelState.nextLevel:
                    int currentLevel = _currentLevel + 1;
                    if (currentLevel > GameResourceManager.Instance.GetMapCount()) currentLevel = 1;
                    PlayerPrefs.SetInt("current_level", currentLevel);
                    State = LevelState.playing;
                    break;
                default:
                    break;
            }
        };

        State = LevelState.playing;
    }

    private void SetUpLevelController()
    {
        _levelController.Init();
        _levelController.OnLose += () => State = LevelState.losing;
        _levelController.OnWin += () => State = LevelState.winning;
    }

    private void LoadLevel() 
    {
        _levelController.LoadMap(_currentLevel);

        PlayerController playerController = _levelController.GetMap().GetPlayer();

        if(playerController)
        {
            HealthController healthController = playerController.GetComponent<HealthController>();
            _healthBarController.HealthController = healthController;
            _healthBarController.Init(healthController.CurrentHealth);
        }
    }

    private int GetPlayerAttackCount() => _levelController.GetMap().GetPlayer().AttackCount;
    private int GetPlayerCurrentHealth() => _levelController.GetMap().GetPlayer().GetComponent<HealthController>().CurrentHealth;
}

public enum LevelState { playing, losing, winning, nextLevel }
