using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
public class NewWeapon : ScriptableObject
{
    public string weaponName;

    public float fireRate;
    public float maxRange;
    public float accuracy;
    public int maxCapacity;

    [TextArea]
    public string description;

    public Sprite weaponSprite;
    public Sprite ammoSprite;

    public AmmoType ammoType;
}

public enum AmmoType
{
    small,
    medium,
    large,
    special
}