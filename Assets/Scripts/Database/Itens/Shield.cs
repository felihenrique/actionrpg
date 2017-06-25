using System;
using UnityEngine;

public class Shield : Durable, IEquipable
{
	public float BlockChance;
	public float DamageTakenMultiplier;

	public void Equip(GameObject obj) {
	}

	public void UnEquip(GameObject obj) {
	}
}