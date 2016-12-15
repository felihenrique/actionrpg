using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Item {
	public enum GroupType
	{
		Assistance,
		Crafting,
		Exploration,
		Treasure,
		Equipment
	}
	public GroupType group;
	public Sprite sprite;
	public string name;
	public string description;
	public string animationName;
	public short price;
	public bool consumable;
	public virtual void Use(GameObject obj) {}
	public DateTime timeAcquired;
}
