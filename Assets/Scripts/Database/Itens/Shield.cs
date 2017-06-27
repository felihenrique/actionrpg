using System;
using UnityEngine;

public class Shield : Durable, IEquipable
{
	public float BlockChance;
	public float DamageTakenMultiplier;

	[SerializeField]
	private Slot slot;

	public Slot Slot { 
		get { return slot; }
	}

	public void Equip(GameObject obj) {
	}

	public void UnEquip() {
	}
}