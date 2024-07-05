using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterPosition
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private GameObject _character;
    public GameObject Character => _character;

    public void SetUpPosition()
    {
        _character.transform.position = _transform.position;
    }
}

public class Map : MonoBehaviour
{
    public int Id { get; private set; }
    [SerializeField]
    private List<CharacterPosition> _characterPositionList;

    private List<IController> _characterControllerList;

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
        LoadCharacters();
    }

    private void SetUpMap()
    {
        SetUpEnemyEvent();
        SetUpPlayerEvent();
    }

    private void ResetMap()
    {
        OnEnemyDead = null;
        OnPlayerDead = null;
        ResetCharacters();
    }

    private void LoadCharacters()
    {
        _characterControllerList = new List<IController>();

        for(int i = 0; i < _characterPositionList.Count; i++)
        {
            CharacterPosition characterPosition = _characterPositionList[i];
            IController controllerClone = Instantiate(characterPosition.Character, transform).GetComponent<IController>();

            controllerClone.Init();
            _characterControllerList.Add(controllerClone);
            characterPosition.SetUpPosition();
        }
    }

    private void SetUpEnemyEvent()
    {
        List<EnemyController> enemyControllers = GetEnemies();

        for(int i = 0; i < enemyControllers.Count; i++)
        {
            enemyControllers[i].OnDead += () => OnEnemyDead?.Invoke();
        }
    }

    private void SetUpPlayerEvent()
    {
        PlayerController playerController = GetPlayer();
        playerController.OnDead += () => OnPlayerDead?.Invoke();
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

    public PlayerController GetPlayer()
    {
        PlayerController playerController = null;

        for (int i = 0; i < _characterControllerList.Count; i++)
        {
            playerController = _characterControllerList[i].MonoBehaviour.GetComponent<PlayerController>();

            if (playerController) break;
        }

        return playerController;
    }

    private List<EnemyController> GetEnemies()
    {
        List<EnemyController> enemyControllerList = new List<EnemyController>();

        for (int i = 0; i < _characterControllerList.Count; i++)
        {
            EnemyController enemyController = _characterControllerList[i].MonoBehaviour.GetComponent<EnemyController>();

            if (enemyController == null) continue;

            enemyControllerList.Add(enemyController);
        }

        return enemyControllerList;
    }

    public int GetAliveEnemies()
    {
        int count = 0;
        List<EnemyController> enemies = GetEnemies();

        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].IsDead) continue;

            count++;
        }

        return count;
    }
}
