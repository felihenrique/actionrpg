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
		
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Item : MonoBehaviour {
	public GroupType Group;
	public DateTime DateAcquired { get; }
	public string Description;
	public short Price;
	// Indica se pode usar o método Use()
	public bool Consumable;

	public Item()
	{
		DateAcquired = DateTime.Now;
	}

	public virtual void Use(GameObject obj) {}

	public override bool Equals (object other)
	{
		Item i = other as Item;
		if (other == null)
			return false;
		return i.name == name;
	}

	public override int GetHashCode ()
	{
		return name.GetHashCode();
	}
}