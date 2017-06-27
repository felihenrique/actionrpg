using System;
using UnityEngine;

public class Armor : Durable, IEquipable, ILevelable
{
	public float PhysicalResistance;
	public float MagicalResistance;
	public float HpGain;
	public float MpGain;
	public float LevelUpMultiplier;

	private DamageSystem dmgSys;
	private HpSystem hpSys;
	private MpSystem mpSys;
	[SerializeField]
	private Slot slot;
	private int level;

	public Slot Slot {
		get { return slot; }
	}

	public int Level {
		get { return level; }
	}

	private void IncreaseStats() {
		dmgSys?.ChangePhysicalResistance(PhysicalResistance);
		dmgSys?.ChangeMagicalResistance(MagicalResistance);

		if (hpSys != null) {
			hpSys.Hp += HpGain;
			mpSys.Mp += MpGain;
		}
	}

	private void DecreaseStats() {
		dmgSys?.ChangePhysicalResistance(-PhysicalResistance);
		dmgSys?.ChangeMagicalResistance(-MagicalResistance);

		if (hpSys !=  null) {
			hpSys.Hp -= HpGain;
			mpSys.Mp -= MpGain;
		}
	}

	public void Equip(GameObject obj) {
		dmgSys = obj.GetComponent<DamageSystem> ();
		hpSys = obj.GetComponent<HpSystem> ();
		mpSys = obj.GetComponent<MpSystem> ();
		IncreaseStats ();
	}

	public void UnEquip() {
		DecreaseStats ();
		dmgSys = null;
		hpSys = null;
		mpSys = null;
	}

	public void LevelUp() {
		DecreaseStats ();
		PhysicalResistance *= LevelUpMultiplier;
		MagicalResistance *= LevelUpMultiplier;
		HpGain *= LevelUpMultiplier;
		MpGain *= LevelUpMultiplier;
		IncreaseStats ();
		level++;
	}
}