using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Item/Consumable Item")]
public class NewConsumableItem : ScriptableObject
{
    public string consumableName;
    public float consumeTime;
    public int healthRecovery;
    public int staminaRecovery;
    public float speedBuff;

    public ConsType consType;
}

public enum ConsType
{
    Food,
    HealthKit,
    Buff,
    Potion
}