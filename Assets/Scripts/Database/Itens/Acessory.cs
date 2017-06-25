using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Accessory : Item, IEquipable {
	
	public float HpGainPercent;
	public float MpGainPercent;
	public float MagicalAttackMultiplier;
	public float AttackMultiplier;

	public void Equip(GameObject obj) {
		
	}

	public void UnEquip(GameObject obj) {
		
	}
}
