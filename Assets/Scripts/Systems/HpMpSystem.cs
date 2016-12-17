using UnityEngine;
using System.Collections;

public class HpMpSystem : MonoBehaviour {

	private float mp = 100;
	private float hp = 100;
	private float maxhp = 100;
	private float maxmp = 100;

	public delegate void AttrChangeHandler (float quantity);
	public delegate void BlockDamageHandler ();
	public delegate void DeathHandler ();
	// Caso o valor chamado nesse evento seja maior que zero o character ganhou hp, caso seja menor que zero o character tomou dano e caso
	// seja = 0 o character se defendeu de um ataque
	public event AttrChangeHandler hpChange;
	public event AttrChangeHandler mpChange;
	public event AttrChangeHandler maxHPChange;
	public event AttrChangeHandler maxMPChange;
	public event DeathHandler Died;
	public event BlockDamageHandler BlockedDamage;

	void Start() {
		GetComponent<EquipmentSystem> ().EquipAdded += onEquipAdded;
		GetComponent<EquipmentSystem> ().EquipRemoved += onEquipRemoved;
	}

	void onEquipAdded(Equipment equip) {
		AddMaxHP (equip.hpGain + ((1 + equip.hpGainPercent) * maxhp - maxhp));
		AddMaxMP (equip.mpGain + ((1 + equip.mpGainPercent) * maxmp - maxmp));
	}

	void onEquipRemoved(Equipment equip) {
		ReduceMaxHP (equip.hpGain + (maxhp - (maxhp / (1 + equip.hpGainPercent))));
		ReduceMaxMP (equip.mpGain + (maxmp - (maxmp / (1 + equip.mpGainPercent))));
	}

	public void LoseHP(float quantity, float resistance) {
		if (hp == 0) return;
		float damage = quantity - resistance;
		if (damage <= 0) {
			if (BlockedDamage != null) BlockedDamage ();
			return;
		}
		hp -= damage;
		if (hp < 0) {
			hp = 0;
			if (Died != null) Died ();
		}
		hpChange (damage); 
	}

	public void GainHP(float quantity) {
		hp += quantity;
		hp = Mathf.Clamp (hp, 0, maxhp);
		if (hpChange != null) hpChange (quantity);
	}

	public void LoseMP(float quantity) {
		mp -= quantity;
		mp = Mathf.Clamp (mp, 0, maxmp);
		if (mpChange != null) mpChange (quantity);
	}

	public void GainMP(float quantity) {
		mp += quantity;
		mp = Mathf.Clamp (mp, 0, maxmp);
		if (mpChange != null) mpChange (quantity);
	}

	public void AddMaxHP(float quantity) {
		maxhp += quantity;
		if (maxHPChange != null) maxHPChange (quantity);
	}

	public void ReduceMaxHP(float quantity) {
		maxhp -= quantity;
		hp = Mathf.Clamp (hp, 0, maxhp);
		if (maxHPChange != null) maxHPChange (-quantity);
	}

	public void AddMaxMP(float quantity) {
		maxmp += quantity;
		if (maxMPChange != null) maxMPChange (quantity);
	}

	public void ReduceMaxMP(float quantity) {
		maxmp -= quantity;
		mp = Mathf.Clamp (mp, 0, maxmp);
		if (maxMPChange != null) maxMPChange (-quantity);
	}

	public float HP {
		get { return hp; }
	}

	public float MP {
		get { return mp; }
	}

	public float MaxHP {
		get { return maxhp; }
	}

	public float MaxMP {
		get { return maxmp; }
	}
}

