using System;
using UnityEngine;

public class Weapon : Durable, IEquipable, ILevelable
{
	public float Attack;
	public float MagicAttack;
	public float LevelupMultiplier;

	[SerializeField]
	private Slot slot;
	private DamageSystem dmgSys;
	private int level;

	public Slot Slot { 
		get { return slot; }
	}

	public int Level {
		get { return level; }
	}

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

	public void LevelUp() {
		DecreaseStats ();
		Attack *= LevelupMultiplier;
		MagicAttack *= LevelupMultiplier;
		IncreaseStats ();
		level++;
	}
}