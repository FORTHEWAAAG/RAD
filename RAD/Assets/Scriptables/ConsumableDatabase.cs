using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumables", menuName = "Database/New Consumable Database")]
public class ConsumableDatabase : ScriptableObject
{
    public List<NewConsumableItem> allConsumableItems;
}
