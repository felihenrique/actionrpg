using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum Slot
{
	Weapon,
	Chestplate,
	Legs,
	Boots,
	Helmet,
	Pendant,
	Ring1,
	Ring2,
	Shield
}

public class EquipmentSystem : MonoBehaviour {
	
	private Dictionary<Slot, IEquipable> equips;

	public delegate void EquipChangeHandler (IEquipable armor);
	public event EquipChangeHandler EquipAdded;
	public event EquipChangeHandler EquipRemoved;

	void Start () {
		equips = new Dictionary<Slot, IEquipable> ();
	}
	// TODO: Modificar aqui para colocar EquipmentType
		
	public void Equip(IEquipable equipment) {
		if (equips.ContainsKey(equipment.Slot))
			return;
		equipment.Equip (gameObject);
		equips[equipment.Slot] = equipment;
		EquipAdded?.Invoke (equipment);
	}

	public void Unequip(IEquipable equipment) {
		if (!equips.ContainsKey(equipment.Slot))
			return;
		equipment.UnEquip (gameObject);
		equips.Remove (equipment.Slot);
		EquipRemoved?.Invoke (equipment);
	}
}