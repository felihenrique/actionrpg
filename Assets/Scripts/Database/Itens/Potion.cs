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

	public Potion() {
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
