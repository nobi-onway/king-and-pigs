using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Settings")]
public class Data : ScriptableObject
{
    public List<MapSettings> MapList;
}

[Serializable]
public class MapSettings
{
    public string Name;
    public int Id => Name.GetHashCode();

    public Map Map;
}