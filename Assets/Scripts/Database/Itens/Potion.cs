using System;
using UnityEngine;
using System.Runtime.Serialization;

public class Potion : Item
{
	public int amountHP;
	public int amountMP;

	public override void Use (GameObject obj)
	{
		HpMpSystem system = obj.GetComponent<HpMpSystem> ();
		if (system != null) {
			system.GainMP (amountMP);
			system.GainHP (amountHP);
		}
	}
}
