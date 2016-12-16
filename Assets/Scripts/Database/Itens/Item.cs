using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Item : ISerializationCallbackReceiver {
	public enum GroupType
	{
		Assistance = 1,
		Crafting = 2,
		Exploration = 3,
		Treasure = 4,
		Equipment = 5
	}
	public GroupType group;
	[NonSerialized]
	public Sprite sprite;
	public string name;
	public string description;
	public string animationName;
	public short price;
	public bool consumable;
	public virtual void Use(GameObject obj) {}
	public string timeAcquired;
	[SerializeField]
	private string spriteName;

	public void OnAfterDeserialize()
	{
		ItemDatabase database = GameObject.Find ("ItemDatabase").GetComponent<ItemDatabase>();
		if (database == null) {
			return;
		}			
		Sprite spr = System.Array.Find (database.sprites, (Sprite s) => {
			return s.name == spriteName;
		});
		if (spr != null) {
			sprite = spr;
		}

	}

	public void OnBeforeSerialize()
	{
		spriteName = sprite.name;
	}
}
