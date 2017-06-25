using System;
using UnityEngine;

public class Armor : Durable, IEquipable, ILevelable
{
	public short PhysicalResistance;
	public short MagicalResistance;
	public float HpGain;
	public float MpGain;
	public float LevelUpMultiplier;

	private DamageSystem dmgSys;
	private HpSystem hpSys;
	private MpSystem mpSys;


	private void IncreaseStats() {
		dmgSys?.TotalPhysicalResistance += PhysicalResistance;
		dmgSys?.TotalMagicalResistance += MagicalResistance;

		hpSys?.Hp += HpGain;

		mpSys?.Mp += MpGain;
	}

	private void DecreaseStats() {
		dmgSys?.TotalPhysicalResistance -= PhysicalResistance;
		dmgSys?.TotalMagicalResistance -= MagicalResistance;

		hpSys?.Hp -= HpGain;

		mpSys?.Mp -= MpGain;
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
	}
}