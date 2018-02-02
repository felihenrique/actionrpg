using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : Equipable {
	
	public float HpMultiplier;
	public float MpMultiplier;
	public float MagicalAttackMultiplier;
	public float AttackMultiplier;

    private Attributes attr;

    private void IncreaseStats()
    {
        if (attr != null)
        {
            attr.AddFixed(FixedAttr.HpMultiplier, HpMultiplier);
            attr.AddFixed(FixedAttr.MpMultiplier, MpMultiplier);
            attr.AddFixed(FixedAttr.MagicAttackMultiplier, MagicalAttackMultiplier);
            attr.AddFixed(FixedAttr.AttackMultiplier, AttackMultiplier);
        }
    }

    private void DecreaseStats()
    {
        if (attr != null)
        {
            attr.AddFixed(FixedAttr.HpMultiplier, -HpMultiplier);
            attr.AddFixed(FixedAttr.MpMultiplier, -MpMultiplier);
            attr.AddFixed(FixedAttr.MagicAttackMultiplier, -MagicalAttackMultiplier);
            attr.AddFixed(FixedAttr.AttackMultiplier, -AttackMultiplier);
        }
    }

    private override void OnEquip(GameObject obj) {
        attr = obj.GetComponent<Attributes>();
	}

    private override void OnUnequip() {
		
	}
}
