using System;
using UnityEngine;

public enum ArmorType
{
	Helmet = 1,
	ChestPlate = 2,
	Legs = 3,
	Boots = 4,
	Shield = 5
}

public class Armor : Item, IEquipable
{
	public short PhysicalResistance;
	public short MagicalResistance;
	public short Durability;
	public float HpGain;
	public float MpGain;

	public ArmorType Type;

	public void Equip(GameObject obj) { 
		
	}

	public void UnEquip(GameObject obj) {

	}
}