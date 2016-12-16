using System;
using UnityEngine;
using System.Runtime.Serialization;

[Serializable]
public class Potion : Item
{
	public int amountHP;
	public int amountMP;
	public override void Use (GameObject obj)
	{
		HealthMpSystem system = obj.GetComponent<HealthMpSystem> ();
		if (system) {
			system.GainMP (amountMP);
			system.GainHP (amountHP);
		}
	}

	public Potion() 
	{
		
	}

	public override object Clone ()
	{
		Potion temp = new Potion ();
		temp.group = group;
		temp.sprite = sprite;
		temp.itemName = itemName;
		temp.description = description;
		temp.animationName = animationName;
		temp.price = price;
		temp.consumable = consumable;
		temp.amountHP = amountHP;
		temp.amountMP = amountMP;
		return temp;
	}

	protected Potion(SerializationInfo info, StreamingContext context) : base(info, context)
	{
		amountHP = info.GetInt32 ("amountHP");
		amountMP = info.GetInt32 ("amountMP");
	}

	public override void GetObjectData (SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData (info, context);
		info.AddValue ("amountHP", amountHP);
		info.AddValue ("amountMP", amountMP);
	}
}
