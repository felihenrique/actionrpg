using System;
using UnityEngine;

public class HealthPotion : Item
{
	public int amount;
	public override void Use (GameObject obj)
	{
		HealthMpSystem system = obj.GetComponent<HealthMpSystem> ();
		if (system != null) {
			system.GainHP (amount);
		}
	}
}
