using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private List<Map> _loadedMapList;

    private Map _currentLoadedMap;

    [SerializeField]
    private Transform _mapHolder;

    public event Action OnLose;
    public event Action OnWin;

    public void Init()
    {
        _loadedMapList = new List<Map>();
    }

    private Map GetLoadedMapAtLevel(MapSettings mapSettings)
    {
        return _loadedMapList.Find(map => map.Id == mapSettings.Id);
    }

    public void LoadMap(int level)
    {
        if (_currentLoadedMap != null) _currentLoadedMap.IsActive = false;

        MapSettings mapSettings = GameResourceManager.Instance.GetMapSetting(level - 1);

        _currentLoadedMap = GetLoadedMapAtLevel(mapSettings);

        if (_currentLoadedMap == null)
        {
            Map mapClone = Instantiate(mapSettings.Map, _mapHolder).GetComponent<Map>();

            _loadedMapList.Add(mapClone);
            _currentLoadedMap = mapClone;
            _currentLoadedMap.Init(mapSettings);
        }

        _currentLoadedMap.IsActive = true;

        _currentLoadedMap.OnEnemyDead += () =>
        {
            int numsOfAliveEnemy = _currentLoadedMap.GetAliveEnemies();
            if (numsOfAliveEnemy == 0)
            {
                OnWin?.Invoke();
                _currentLoadedMap.GetPlayer().State = ControllerState.winning;
            }
        };

        _currentLoadedMap.OnPlayerDead += () =>
        {
            OnLose?.Invoke();
        };
    }

    public Map GetMap() => _currentLoadedMap;
}
