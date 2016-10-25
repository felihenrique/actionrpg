using System;
using UnityEngine;

public class ManaPotion : Item
{
	public int amount;
	public override void Use (GameObject obj)
	{
		HealthMpSystem system = obj.GetComponent<HealthMpSystem> ();
		if (system) {
			system.GainMP (amount);
		}
	}
}
