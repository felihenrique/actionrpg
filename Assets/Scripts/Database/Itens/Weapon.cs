using System;
using UnityEngine;

public class Weapon : Item
{
	public float Attack;
	public float MagicAttack;

    private Attributes attr;

	private void IncreaseStats() {
        attr.AddFixed(FixedAttr.Attack, Attack);
        attr.AddFixed(FixedAttr.MagicAttack, MagicAttack);
	}

	private void DecreaseStats() {
        attr.AddFixed(FixedAttr.Attack, -Attack);
        attr.AddFixed(FixedAttr.MagicAttack, -MagicAttack);
	}

	public void Equip(GameObject obj) {
        attr = obj.GetComponent<Attributes> ();
		IncreaseStats ();
	}

	public void UnEquip() {
		DecreaseStats ();
        attr = null;
	}
}