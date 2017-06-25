using System;
using UnityEngine;

public enum WeaponType
{
	Axe = 1,
	Sword = 2,
	Club = 3
}

public class Weapon : Item, IEquipable
{
	public short Durability;
	public short Attack;
	public short MagicalAttack;
	public WeaponType Type;

	public void Equip(GameObject obj) {
		
	}

	public void UnEquip(GameObject obj) {
		
	}
}