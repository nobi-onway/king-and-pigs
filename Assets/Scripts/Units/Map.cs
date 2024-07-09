using System;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int Id { get; private set; }

    [SerializeField]
    private List<IController> _characterControllerList;

    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private List<EnemyController> _enemyControllerList;

    public event Action OnEnemyDead;
    public event Action OnPlayerDead;

    private bool _isActive;
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            gameObject.SetActive(value);

            if (_isActive) SetUpMap();

            if (!_isActive) ResetMap();
        }
    }

    public void Init(MapSettings mapSettings)
    {
        Id = mapSettings.Id;
        InitCharacters();
    }

    private void SetUpMap()
    {
        SetUpEnemyEvent();
        SetUpPlayerEvent();
    }

    private void ResetMap()
    {
        //OnEnemyDead = null;
        //OnPlayerDead = null;
        //ResetCharacters();
        Destroy(gameObject);
    }

    private void InitCharacters()
    {
        _characterControllerList = new List<IController>();

        _characterControllerList.Add(_playerController);
        for (int i = 0; i < _enemyControllerList.Count; i++)
        {
            _characterControllerList.Add(_enemyControllerList[i]);
        }

        for (int i = 0; i < _characterControllerList.Count; i++)
        {
            _characterControllerList[i].Init();
        }
    }

    private void SetUpEnemyEvent()
    {
        for(int i = 0; i < _enemyControllerList.Count; i++)
        {
            _enemyControllerList[i].OnDead += () => OnEnemyDead?.Invoke();
        }
    }

    private void SetUpPlayerEvent()
    {
        _playerController.OnDead += () => OnPlayerDead?.Invoke();
    }

    private void ResetCharacters()
    {
        if (_characterControllerList == null) return;

        for (int i = 0; i < _characterControllerList.Count; i++)
        {
            IController controller = _characterControllerList[i];
            controller.Reset();
        }
    }

    public PlayerController GetPlayer() => _playerController;

    public int GetAliveEnemies()
    {
        int count = 0;
        List<EnemyController> enemies = _enemyControllerList;

        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].IsDead) continue;

            count++;
        }

        return count;
    }
}
