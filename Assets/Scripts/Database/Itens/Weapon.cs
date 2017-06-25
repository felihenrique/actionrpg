using System;
using UnityEngine;

public class Weapon : Item, IEquipable
{
	public short Durability;
	public short Attack;
	public short MagicalAttack;

	public void Equip(GameObject obj) {
		
	}

	public void UnEquip(GameObject obj) {
		
	}
}