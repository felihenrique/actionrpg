using UnityEngine;
using System.Collections;

public class HealthMpSystem : MonoBehaviour {

	private float mp;
	private float hp;
	private float maxhp;
	private float maxmp;

	public delegate void HpChangeHandler (float quantity);
	public delegate void MpChangeHandler (float quantity);
	public delegate void MaxHPChangeHandler (float quantity);
	public delegate void MaxMPChangeHandler (float quantity);
	public delegate void BlockDamageHandler ();
	public delegate void DeathHandler ();
	// Caso o valor chamado nesse evento seja maior que zero o character ganhou hp, caso seja menor que zero o character tomou dano e caso
	// seja = 0 o character se defendeu de um ataque
	public event HpChangeHandler hpChange;
	public event MpChangeHandler mpChange;
	public event MaxHPChangeHandler maxHPChange;
	public event MaxMPChangeHandler maxMPChange;
	public event DeathHandler Died;
	public event BlockDamageHandler BlockedDamage;

	void Start() {
		GetComponent<EquipmentSystem> ().EquipAdded += onEquipAdded;
		GetComponent<EquipmentSystem> ().EquipRemoved += onEquipRemoved;
	}

	void onEquipAdded(Equipment equip) {
		if (equip.hpGain != 0) {
			AddMaxHP (equip.hpGain);
		}
		else if (equip.hpGainPercent != 0) {
			AddMaxHP ((1 + equip.hpGainPercent) * maxhp - maxhp);
		}

		if (equip.mpGain != 0) {
			AddMaxMP (equip.mpGain);
		}
		else if (equip.mpGainPercent != 0) {
			AddMaxMP ((1 + equip.mpGainPercent) * maxmp - maxmp);
		}
	}

	void onEquipRemoved(Equipment equip) {
		if (equip.hpGain != 0) {
			ReduceMaxHP (equip.hpGain);
		}
		if (equip.hpGainPercent != 0) {
			ReduceMaxHP ( maxhp - (maxhp / (1 + equip.hpGainPercent)) );
		}

		if (equip.mpGain != 0) {
			ReduceMaxMP (equip.mpGain);
		}
		if (equip.mpGainPercent != 0) {
			ReduceMaxMP ( maxmp - (maxmp / (1 + equip.mpGainPercent)) );
		}
	}

	public void LoseHP(float quantity, float resistance) {
		if (hp == 0) {
			return;
		}
		float oldhp = hp;
		float damage = quantity - resistance > 0 ? quantity - resistance : 0;
		if (damage == 0) {
			if (BlockedDamage != null) {
				BlockedDamage ();
			}
			return;
		}
		hp -= damage;
		if (hp < 0) {
			hp = 0;
			if (Died != null) {
				Died ();
			}
		}
		hpChange (hp - oldhp); 
	}

	public void GainHP(float quantity) {
		float oldhp = hp;
		hp += quantity;
		if (hp > maxhp)
			hp = maxhp;
		if (hpChange != null) {
			hpChange (hp - oldhp);
		}
	}

	public void LoseMP(float quantity) {
		float oldmp = mp;
		mp -= quantity;
		if (mp < 0)
			mp = 0;
		if (mpChange != null) {
			mpChange (mp - oldmp);
		}
	}

	public void GainMP(float quantity) {
		float oldmp = mp;
		mp += quantity;
		if (mp > maxmp)
			mp = maxmp;
		if (mpChange != null) {
			mpChange (mp - oldmp);
		}
	}

	public void AddMaxHP(float quantity) {
		maxhp += quantity;
		hp = maxhp;
		if (maxHPChange != null) {
			maxHPChange (quantity);
		}
	}

	public void ReduceMaxHP(float quantity) {
		maxhp -= quantity;
		if (hp > maxhp) {
			hp = maxhp;
		}
		if (maxHPChange != null) {
			maxHPChange (-quantity);
		}
	}

	public void AddMaxMP(float quantity) {
		maxmp += quantity;
		mp = maxmp;
		if (maxMPChange != null) {
			maxMPChange (quantity);
		}
	}

	public void ReduceMaxMP(float quantity) {
		maxmp -= quantity;
		if (mp > maxmp) {
			mp = maxmp;
		}
		if (maxMPChange != null) {
			maxMPChange (-quantity);
		}
	}

	public float getHP() {
		return hp;
	}

	public float getMP() {
		return mp;
	}

	public float getMaxHP() {
		return maxhp;
	}

	public float getMaxMP() {
		return maxmp;
	}
}

