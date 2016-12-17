using UnityEngine;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Item : MonoBehaviour {
	public enum GroupType
	{
		Assistance = 1,
		Crafting = 2,
		Exploration = 3,
		Treasure = 4,
		Equipment = 5
	}

	public Item()
	{
		_timeAcquired = DateTime.Now;
	}

	public DateTime TimeAcquired
	{
		get { return _timeAcquired; }
		set { _timeAcquired = value; }
	}

	public GroupType group;
	public bool stackable;
	public int stackMaxSize;
	public int stackSize;
	public string itemName;
	public string description;
	public string animationName;
	public short price;
	public bool consumable;
	public virtual void Use(GameObject obj) {}
	protected DateTime _timeAcquired;
}