using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Item {
	public string group;
	public Sprite sprite;
	public string name;
	public string description;
	public string animationName;
	public short price;
	public bool consumable;
	public virtual void Use(GameObject obj) {}
	public double timeAcquired;
}
