using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EquipmentSystem : MonoBehaviour {
	private Dictionary<string, Armor>  armors;

	public delegate void EquipChangeHandler (Armor armor);

	public event EquipChangeHandler onEquipAdd;
	public event EquipChangeHandler onEquipRemove;

	// Use this for initialization
	void Start () {
		armors = new Dictionary<string, Armor> ();
	}
		
	public void EquipArmor(string name, Armor armor) {
		if (armors.ContainsKey(name)) {
			UnequipArmor(name);
		}
		armors.Add (name, armor);
		onEquipAdd (armor);
	}

	public void UnequipArmor(string name) {
		if (armors.ContainsKey(name)) {
			onEquipRemove (armors [name]);
			armors.Remove (name);
		}
	}
}
