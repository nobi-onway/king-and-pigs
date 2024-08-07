using System.Collections.Generic;
using UnityEngine;

public class GameResourceManager : MonoBehaviour
{
    [SerializeField]
    private Data _data;

    public static GameResourceManager Instance { get; private set; }

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

    public MapSettings GetMapSetting(int index)
    {
        return _data.MapList[index];
    }

    public int GetMapCount() => _data.MapList.Count;

    public List<WeaponSettings> GetWeaponSettingsList() => _data.WeaponList;

}
