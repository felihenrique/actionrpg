using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
public class EquipmentSystem : MonoBehaviour 
{

    private Dictionary<Slot, Equipable> equips;

    public delegate void EquipChangeDel (Equipable armor);
    public event EquipChangeDel EquipAdded;
    public event EquipChangeDel EquipRemoved;

    void Start () 
    {
        equips = new Dictionary<Slot, Equipable> ();
    }

    public void Equip(Equipable equipment) 
    {
        if (!equips.ContainsKey(equipment.slot))
            return;
        object[] param = { gameObject };
        equipment.GetType().GetMethod("OnEquip").Invoke(equipment, param);
        equips[equipment.slot] = equipment;
        if (EquipAdded != null) {
            EquipAdded (equipment);
        }
    }

    public void Unequip(Equipable equipment) 
    {
        if (!equips.ContainsKey(equipment.slot))
            return;
        equipment.GetType().GetMethod("OnUnequip").Invoke(equipment, null);
        equips.Remove (equipment.slot);
        if (EquipRemoved != null) {
            EquipRemoved (equipment);
        }
    }
}   
