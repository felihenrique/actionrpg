using System;
using UnityEngine;

public class Armor : Item, IEquipable
{
	public short PhysicalResistance;
	public short MagicalResistance;
	public short Durability;
	public float HpGain;
	public float MpGain;

	public void Equip(GameObject obj) { 
		
	}

	public void UnEquip(GameObject obj) {

	}
}