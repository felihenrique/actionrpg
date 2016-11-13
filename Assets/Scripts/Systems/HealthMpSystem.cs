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
	public delegate void DeathHandler ();
	// Caso o valor chamado nesse evento seja maior que zero o character ganhou hp, caso seja menor que zero o character tomou dano e caso
	// seja = 0 o character se defendeu de um ataque
	public event HpChangeHandler hpChange;
	public event MpChangeHandler mpChange;
	public event MaxHPChangeHandler maxHPChange;
	public event MaxMPChangeHandler maxMPChange;
	public event DeathHandler onDeath;

	public void LoseHP(float quantity, float resistance) {
		float oldhp = hp;
		float damage = quantity - resistance > 0 ? quantity - resistance : 0;
		hp -= damage;
		if (hp < 0) {
			hp = 0;
			if (onDeath != null) {
				onDeath ();
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

