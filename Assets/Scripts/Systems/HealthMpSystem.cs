using UnityEngine;
using System.Collections;

public class HealthMpSystem : MonoBehaviour {

	private int mp;
	private int hp;
	private int maxhp;
	private int maxmp;

	public delegate void HpChangeHandler (int quantity);
	public delegate void MpChangeHandler (int quantity);
	public delegate void MaxHPChangeHandler (int quantity);
	public delegate void MaxMPChangeHandler (int quantity);
	public delegate void DeathHandler ();
	// Caso o valor chamado nesse evento seja maior que zero o character ganhou hp, caso seja menor que zero o character tomou dano e caso
	// seja = 0 o character se defendeu de um ataque
	public event HpChangeHandler hpChange;
	public event MpChangeHandler mpChange;
	public event MaxHPChangeHandler maxHPChange;
	public event MaxMPChangeHandler maxMPChange;
	public event DeathHandler onDeath;

	public void LoseHP(int quantity, int resistance) {
		int oldhp = hp;
		int damage = quantity - resistance > 0 ? quantity - resistance : 0;
		hp -= damage;
		if (hp < 0) {
			hp = 0;
			if (onDeath != null) {
				onDeath ();
			}
		}
		hpChange (hp - oldhp); 
	}

	public void GainHP(int quantity) {
		int oldhp = hp;
		hp += quantity;
		if (hp > maxhp)
			hp = maxhp;
		if (hpChange != null) {
			hpChange (hp - oldhp);
		}
	}

	public void LoseMP(int quantity) {
		int oldmp = mp;
		mp -= quantity;
		if (mp < 0)
			mp = 0;
		if (mpChange != null) {
			mpChange (mp - oldmp);
		}
	}

	public void GainMP(int quantity) {
		int oldmp = mp;
		mp += quantity;
		if (mp > maxmp)
			mp = maxmp;
		if (mpChange != null) {
			mpChange (mp - oldmp);
		}
	}

	public void AddMaxHP(int quantity) {
		maxhp += quantity;
		hp = maxhp;
		if (maxHPChange != null) {
			maxHPChange (quantity);
		}
	}

	public void ReduceMaxHP(int quantity) {
		maxhp -= quantity;
		if (hp > maxhp) {
			hp = maxhp;
		}
		if (maxHPChange != null) {
			maxHPChange (-quantity);
		}
	}

	public void AddMaxMP(int quantity) {
		maxmp += quantity;
		mp = maxmp;
		if (maxMPChange != null) {
			maxMPChange (quantity);
		}
	}

	public void ReduceMaxMP(int quantity) {
		maxmp -= quantity;
		if (mp > maxmp) {
			mp = maxmp;
		}
		if (maxMPChange != null) {
			maxMPChange (-quantity);
		}
	}

	public int getHP() {
		return hp;
	}

	public int getMP() {
		return mp;
	}

	public int getMaxHP() {
		return maxhp;
	}

	public int getMaxMP() {
		return maxmp;
	}
}

