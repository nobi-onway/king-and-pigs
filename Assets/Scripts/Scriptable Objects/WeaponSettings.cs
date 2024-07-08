using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Settings/Weapon")]
public class WeaponSettings : ScriptableObject
{
    public string Name;
    public int Id => Name.GetHashCode();
    public Sprite Image;
    public int AttackValue;
    public int BouncyValue;
    public string Description;
    public WeaponController Controller;
}
