using UnityEngine;
using System.Collections.Generic;
using System;
using RPG.Itens;
using RPG.Systems;

namespace RPG.Systems
{
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
            EquipAdded?.Invoke (equipment);
        }

        public void Unequip(Equipable equipment) 
        {
            if (!equips.ContainsKey(equipment.slot))
                return;
            equipment.GetType().GetMethod("OnUnequip").Invoke(equipment, null);
            equips.Remove (equipment.slot);
            EquipRemoved?.Invoke (equipment);
        }
    }   
}