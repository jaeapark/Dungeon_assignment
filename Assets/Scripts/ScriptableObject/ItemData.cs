using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{ 
    Consumable,
    GameEnd
}

public enum ConsumableType 
{
    Health,
    Hunger
}

[Serializable]
public class ItemDataConsumable 
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public itemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
