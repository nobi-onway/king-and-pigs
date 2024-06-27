using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private List<Map> _mapsInfors; // Get position

    [SerializeField] private Transform _holderMaps;

    private List<GameObject> _mapsPrefabInData;

    public void Init()
    {
        CreateMaps();
    }

    private void CreateMaps()
    {
        for(int i =0; i < _mapsPrefabInData.Count; i++)
        {
            GameObject createMap = Instantiate(_mapsPrefabInData[i], _holderMaps);                       
            _mapsInfors.Add(createMap.GetComponent<Map>());
        }
        DisableAllMaps();
    }

    private void EnableMap(int numberMap)
    {
        for(int i = 0; i <_mapsInfors.Count; i++)
        {
            if (i == numberMap) _mapsInfors[i].OnActive(true);
        }
    }
    private void DisableAllMaps()
    {
        for(int i = 0; i < _mapsInfors.Count; i++)
        {
            _mapsInfors[i].OnActive(false);
        }
    }

    public void LoadMap(int numberMap)
    {
        DisableAllMaps();
        //_mapsInfors[numberMap].SettingMap(...); // Get PlayerPrefab, ListEnemyPrefab
    }


}
