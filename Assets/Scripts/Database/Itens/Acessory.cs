using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AccessoryType
{
	Ring = 1,
	Pendant = 2
}

public class Accessory : Item, IEquipable {
	
	public float HpGainPercent;
	public float MpGainPercent;
	public float MagicalAttackMultiplier;
	public float AttackMultiplier;
	public AccessoryType Type;

	public void Equip(GameObject obj) {
		
	}

	public void UnEquip(GameObject obj) {
		
	}
}
