using System;
using UnityEngine;

public class Armor : Equipable
{
	public float PhysicalResistance;
	public float MagicalResistance;
	public float MaxHpGain;
	public float MaxMpGain;

	private DamageSystem targetDmgSys;
	private HealthSystem tagetHpSys;
	private MpSystem targetMpSys;

	private void IncreaseStats() {
		targetDmgSys?.ChangePhysicalResistance(PhysicalResistance);
		targetDmgSys?.ChangeMagicalResistance(MagicalResistance);

		if (tagetHpSys != null) {
            tagetHpSys.MaxHp += MaxHpGain;
            targetMpSys.MaxMp += MaxMpGain;
		}
	}

	private void DecreaseStats() {
		targetDmgSys?.ChangePhysicalResistance(-PhysicalResistance);
		targetDmgSys?.ChangeMagicalResistance(-MagicalResistance);

		if (tagetHpSys !=  null) {
            tagetHpSys.MaxHp -= MaxHpGain;
            targetMpSys.MaxMp -= MaxMpGain;
		}
	}

    protected override void OnEquip(GameObject obj) {
		targetDmgSys = obj.GetComponent<DamageSystem> ();
		tagetHpSys = obj.GetComponent<HealthSystem> ();
		targetMpSys = obj.GetComponent<MpSystem> ();
		IncreaseStats ();
	}

    protected override void OnUnequip() {
		DecreaseStats ();
		targetDmgSys = null;
		tagetHpSys = null;
		targetMpSys = null;
	}
}