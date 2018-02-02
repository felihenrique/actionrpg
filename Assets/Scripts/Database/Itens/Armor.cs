using System;
using UnityEngine;

public class Armor : Equipable
{
	public float PhysicalResistance;
	public float MagicalResistance;
	public float MaxHpGain;
	public float MaxMpGain;

    private Attributes attr;

	private void IncreaseStats() {
        if (attr != null) 
        {
            attr.AddFixed(FixedAttr.PhysicalResistance, PhysicalResistance);
            attr.AddFixed(FixedAttr.MagicalResistance, MagicalResistance); 
            attr.AddMax(VariableAttr.HP, MaxHpGain);
            attr.AddMax(VariableAttr.MP, MaxMpGain);
		}
	}

	private void DecreaseStats() 
    {
        if (attr != null) 
        {
            attr.AddMax(VariableAttr.HP, -MaxHpGain);
            attr.AddMax(VariableAttr.MP, -MaxMpGain);
            attr.AddFixed(FixedAttr.PhysicalResistance, -PhysicalResistance);
            attr.AddFixed(FixedAttr.MagicalResistance, -MagicalResistance); 
        }
	}

    protected override void OnEquip(GameObject obj) 
    {
        attr = obj.GetComponent<Attributes> ();
		IncreaseStats ();
	}

    protected override void OnUnequip() 
    {
		DecreaseStats ();
        attr = null;
	}
}