using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum EquipmentType
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
	
	private Dictionary<EquipmentType, IEquipable> equips;

	public delegate void EquipChangeHandler (IEquipable armor);
	public event EquipChangeHandler EquipAdded;
	public event EquipChangeHandler EquipRemoved;
	[HideInInspector]
	public int TotalPhysicalResistance;
	[HideInInspector]
	public int TotalMagicalResistance;

	void Start () {
		equips = new HashSet<>();
	}
		
	public void Equip(IEquipable equipment) {
		if (equips.Contains(equipment))
			return;
		equipment.Equip (gameObject);
		equips.Add (equipment);
		EquipAdded?.Invoke (equipment);
	}

	public void Unequip(IEquipable equipment) {
		if (!equips.Contains (equipment))
			return;
		equipment.UnEquip (gameObject);
		equips.Remove (equipment);
		EquipRemoved?.Invoke (equipment);
	}
}