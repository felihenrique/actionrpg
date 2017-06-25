using System;
using UnityEngine;

public class Shield : Item, IEquipable
{
	public float BlockChance;
	public float DamageMultiplier;

	public void Equip(GameObject obj) {
	}

	public void UnEquip(GameObject obj) { 
	}
}