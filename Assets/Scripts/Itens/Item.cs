using UnityEngine;
using System;

public enum GroupType
{
    Assistance = 1,
    Crafting = 2,
    Exploration = 3,
    Treasure = 4,
    Equipment = 5
}

[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour {
    public string itemName;
    public Sprite icon;
    public GroupType group;
    public string description;
    public short price;
    // Indica se pode usar o método Use()
    public bool isUsable;
    public bool isStackable;
    public GameObject effectAplied;

    public virtual void Use(GameObject obj) 
    {
        if (effectAplied != null)
        {
            Instantiate(effectAplied, obj.transform);
        }
    }

    public override string ToString()
    {
        return itemName;
    }
}   
