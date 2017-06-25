using System;
using UnityEngine;

public class Durable : Item
{
	private int durability;
	private int maxDurability;

	public virtual int Durability {
		get { return durability; }
		set {
			durability = Mathf.Clamp (value, 0, maxDurability);
		}
	}

	public virtual int MaxDurability {
		get { return maxDurability; }
		set {
			maxDurability = value;
			durability = Mathf.Clamp (durability, 0, maxDurability);
		}
	}
}

