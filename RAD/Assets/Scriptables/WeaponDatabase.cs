using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Database/New Weapon Database")]
public class WeaponDatabase : ScriptableObject
{
    public List<NewWeapon> allWeapons;
}
