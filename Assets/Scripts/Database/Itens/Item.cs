using UnityEngine;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Item : ISerializable {
	public enum GroupType
	{
		Assistance = 1,
		Crafting = 2,
		Exploration = 3,
		Treasure = 4,
		Equipment = 5
	}
	public GroupType group;
	public Sprite sprite;
	public string itemName;
	public string description;
	public string animationName;
	public short price;
	public bool consumable;
	public virtual void Use(GameObject obj) {}
	public string timeAcquired;

	public Item() {
	}

	public virtual object Clone()
	{
		Item temp = new Item ();
		temp.group = group;
		temp.sprite = sprite;
		temp.itemName = itemName;
		temp.description = description;
		temp.animationName = animationName;
		temp.price = price;
		temp.consumable = consumable;
		return temp;
	}

	protected Item(SerializationInfo info, StreamingContext context)
	{
		group = (GroupType)info.GetValue ("group", typeof(GroupType));
		// Carrega o sprite de uma database //////////////
		IconDatabase database = GameObject.Find ("IconDatabase").GetComponent<IconDatabase> ();
		if (database != null) sprite = database.get(info.GetString("sprite"));
		/////////////////////////////////////////////
		itemName = info.GetString ("itemName");
		description = info.GetString ("description");
		animationName = info.GetString ("animationName");
		price = info.GetInt16("price");
		consumable = info.GetBoolean ("consumable");
		timeAcquired = info.GetString ("timeAcquired");
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		string spriteName = sprite.name;
		info.AddValue ("group", group);
		info.AddValue ("sprite", spriteName);
		info.AddValue ("itemName", itemName);
		info.AddValue ("description", description);
		info.AddValue ("animationName", animationName);
		info.AddValue ("price", price);
		info.AddValue ("consumable", consumable);
		info.AddValue ("timeAcquired", timeAcquired);
	}
}