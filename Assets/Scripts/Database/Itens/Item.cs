using UnityEngine;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System;

public enum GroupType
{
	Assistance = 1,
	Crafting = 2,
	Exploration = 3,
	Treasure = 4,
	Equipment = 5
}

public class Item : MonoBehaviour {
    public string ItemName;
    public Sprite Sprite;
	public GroupType Group;
	public string Description;
	public short Price;
	// Indica se pode usar o método Use()
    public bool IsUsable;
    public bool IsStackable;

	public virtual void Use(GameObject obj) {}
}