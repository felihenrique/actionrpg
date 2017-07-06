using System;
using UnityEngine;

public class Weapon : Item
{
	public float Attack;
	public float MagicAttack;

	private DamageSystem dmgSys;

	private void IncreaseStats() {
		dmgSys?.ChangeAttack (Attack);
		dmgSys?.ChangeMagicAttack (MagicAttack);
	}

	private void DecreaseStats() {
		dmgSys?.ChangeAttack (-Attack);
		dmgSys?.ChangeMagicAttack (-MagicAttack);
	}

	public void Equip(GameObject obj) {
		dmgSys = obj.GetComponent<DamageSystem> ();
		IncreaseStats ();
	}

	public void UnEquip() {
		DecreaseStats ();
		dmgSys = null;
	}
}