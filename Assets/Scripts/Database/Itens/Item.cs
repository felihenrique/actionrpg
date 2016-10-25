using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Item {
	public string tag;
	public int id;
	public string name;
	public string description;
	public string animation_name;
	public short price;
	public bool consumable;
	public virtual void Use(GameObject obj) {}
	public double timeAcquired;
}
