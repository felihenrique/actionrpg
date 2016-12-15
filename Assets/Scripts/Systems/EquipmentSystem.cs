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
		totalPhysicalResistance = 0;
		totalMagicalResistance = 0;
		foreach (var armor in armors) {
			totalPhysicalResistance += armor.Value.physicalResistance;
			totalMagicalResistance += armor.Value.magicalResistance;
		}
	}

	public float PhysicalResist {
		get { return totalPhysicalResistance; }
	}

	public float MagicalResist {
		get { return totalMagicalResistance; }
	}

	public void Equip(Equipment equipment) {
		if (armors.ContainsKey(equipment.type)) 
			Unequip(equipment);
		armors.Add (equipment.type, equipment);
		updateStatus ();
		if (EquipAdded != null) 
			EquipAdded (equipment);
	}

	public void Unequip(Equipment equipment) {
		if (armors.ContainsKey(equipment.type)) {
			if (EquipRemoved != null) EquipRemoved (equipment);
			armors.Remove (equipment.type);
			updateStatus ();
		}
	}
}
