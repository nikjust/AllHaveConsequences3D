using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public Sprite texture;
    public string title;

    public string description;

    // 0 - unusable; 1 - armor; 2 - weapon; 3 - charm
    [HideInInspector]
    public int itemType = 0;

    public Item(string title, string description, Sprite texture)
    {
        this.title = title;
        this.description = description;
    }
}

[System.Serializable]
public class Armor : Item
{
    public int protection;
    [HideInInspector]
    public int itemType = 1;

    public Armor(string title, string description, Sprite texture, int protection) : base(title, description, texture)
    {
        this.protection = protection;
    }
}

[System.Serializable]
public class Weapon : Item
{
    public int damage;
    [HideInInspector]
    public int itemType = 2;

    public Weapon(string title, string description, Sprite texture, int damage) : base(title, description, texture)
    {
        this.damage = damage;
    }
}

public class Inventory : MonoBehaviour
{
    [SerializeField] public Item[] inventory;
    [SerializeField] public Weapon mainHand;
    [SerializeField] public Armor armor;
}