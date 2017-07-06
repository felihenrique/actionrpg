using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Accessory : Item {
	
	public float HpMultiplier;
	public float MpMultiplier;
	public float MagicalAttackMultiplier;
	public float AttackMultiplier;

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
