using System;
using UnityEngine;

public class Weapon : Equipable
{
	public float Attack;
	public float MagicAttack;

    private Attributes attr;

	private void IncreaseStats() {
        if (attr != null)
        {
            attr.AddFixed(FixedAttr.Attack, Attack);
            attr.AddFixed(FixedAttr.MagicAttack, MagicAttack);
        }
	}

	private void DecreaseStats() {
        if (attr != null)
        {
            attr.AddFixed(FixedAttr.Attack, -Attack);
            attr.AddFixed(FixedAttr.MagicAttack, -MagicAttack);
        }
	}

    private override void OnEquip(GameObject obj) {
        attr = obj.GetComponent<Attributes> ();
		IncreaseStats ();
	}

    private override void OnUnequip() {
		DecreaseStats ();
        attr = null;
	}
}