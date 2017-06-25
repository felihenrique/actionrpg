using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Accessory : Durable, IEquipable {
	
	public float HpMultiplier;
	public float MpMultiplier;
	public float MagicalAttackMultiplier;
	public float AttackMultiplier;

	public void Equip(GameObject obj) {
		
	}

	public void UnEquip(GameObject obj) {
		
	}
}
