using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private List<MapSettings> _loadedMapList;

    private MapSettings _currentLoadedMap;

    [SerializeField]
    private Transform _mapHolder;

    public event Action OnLose;
    public event Action OnWin;

    public void Init()
    {
        _loadedMapList = new List<MapSettings>();
    }

    private MapSettings GetLoadedMapAtLevel(MapSettings mapSettings)
    {
        return _loadedMapList.Find(setting => setting.Id == mapSettings.Id);
    }

    public void LoadMap(int level)
    {
        if (_currentLoadedMap != null) _currentLoadedMap.Map.IsActive = false;

        MapSettings mapSettings = GameResourceManager.Instance.GetMapSetting(level - 1);

        _currentLoadedMap = GetLoadedMapAtLevel(mapSettings);

        if (_currentLoadedMap == null)
        {
            Instantiate(mapSettings.Map, _mapHolder);

            _loadedMapList.Add(mapSettings);
            _currentLoadedMap = mapSettings;
        }

        _currentLoadedMap.Map.IsActive = true;

        _currentLoadedMap.Map.OnEnemyDead += () =>
        {
            int numsOfAliveEnemy = _currentLoadedMap.Map.GetAliveEnemies();
            if (numsOfAliveEnemy == 0) OnWin?.Invoke();
        };

        _currentLoadedMap.Map.OnPlayerDead += () =>
        {
            OnLose?.Invoke();
        };
    }

    public Map GetMap() => _currentLoadedMap.Map;
}
