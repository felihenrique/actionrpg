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

[RequireComponent(typeof(Attributes))]
public class EquipmentSystem : MonoBehaviour {
	
    private Dictionary<Slot, Equipable> equips;

    public delegate void EquipChangeHandler (Equipable armor);
	public event EquipChangeHandler EquipAdded;
	public event EquipChangeHandler EquipRemoved;

	void Start () {
        equips = new Dictionary<Slot, Equipable> ();
	}
	// TODO: Modificar aqui para colocar EquipmentType
		
    public void Equip(Equipable equipment) {
		if (equips.ContainsKey(equipment.Slot))
			return;
        object[] param = { gameObject };
        equipment.GetType().GetMethod("OnEquip").Invoke(equipment, param);
		equips[equipment.Slot] = equipment;
		EquipAdded?.Invoke (equipment);
	}

    public void Unequip(Equipable equipment) {
		if (!equips.ContainsKey(equipment.Slot))
			return;
        equipment.GetType().GetMethod("OnUnequip").Invoke(equipment, null);
		equips.Remove (equipment.Slot);
		EquipRemoved?.Invoke (equipment);
	}
}