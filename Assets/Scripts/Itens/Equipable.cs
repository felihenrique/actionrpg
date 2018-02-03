using System;
using UnityEngine;

public abstract class Equipable : Item
{
    public Slot Slot { get { return slot; } }

    [SerializeField]
    protected Slot slot;
    protected abstract void OnEquip(GameObject obj);
    protected abstract void OnUnequip();
}