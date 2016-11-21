using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EquipmentSystem : MonoBehaviour {
	
	private Dictionary<Equipment.EquipmentType, Equipment>  armors;
	private float totalPhysicalResistance;
	private float totalMagicalResistance;

	public delegate void EquipChangeHandler (Equipment armor);
	public event EquipChangeHandler EquipAdded;
	public event EquipChangeHandler EquipRemoved;

	void Start () {
		armors = new Dictionary<Equipment.EquipmentType, Equipment> ();
	}

	void updateStatus() {
		Equipment[] equips = new Equipment[armors.Values.Count];
		armors.Values.CopyTo (equips, 0);

		totalPhysicalResistance = 0;
		totalMagicalResistance = 0;
		for (int i = 0; i < equips.Length; i++) {
			totalPhysicalResistance += equips [i].physicalResistance;
			totalMagicalResistance += equips [i].magicalResistance;
		}
	}

	public float getTotalPhysicalResist () {
		return totalPhysicalResistance;
	}

	public float getTotalMagicalResist() {
		return totalMagicalResistance;
	}

	public void Equip(Equipment equipment) {
		if (armors.ContainsKey(equipment.type)) {
			UnequipArmor(equipment);
		}
		armors.Add (equipment.type, equipment);
		updateStatus ();
		if (EquipAdded != null) {
			EquipAdded (equipment);
		}
	}

	public void UnequipArmor(Equipment equipment) {
		if (armors.ContainsKey(equipment.type)) {
			if (EquipRemoved != null) {
				EquipRemoved (equipment);
			}
			armors.Remove (equipment.type);
			updateStatus ();
		}
	}
}
