using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EquipmentSystem : MonoBehaviour {
	private Dictionary<Armor.ArmorType, Armor>  armors;

	public delegate void EquipChangeHandler (Armor armor);

	public event EquipChangeHandler EquipAdded;
	public event EquipChangeHandler EquipRemoved;

	void Start () {
		armors = new Dictionary<Armor.ArmorType, Armor> ();
	}

	public void EquipArmor(Armor.ArmorType type, Armor armor) {
		if (armors.ContainsKey(type)) {
			UnequipArmor(type);
		}
		armors.Add (type, armor);
		EquipAdded (armor);
	}

	public void UnequipArmor(Armor.ArmorType type) {
		if (armors.ContainsKey(type)) {
			EquipRemoved (armors [type]);
			armors.Remove (type);
		}
	}
}
