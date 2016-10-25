using UnityEngine;
using System.Collections;

public class HealthMpSystem : MonoBehaviour {

	private int mp;
	private int hp;
	private int maxhp;
	private int maxmp;

	public delegate void HpChangeHandler (int quantity);
	public delegate void MpChangeHandler (int quantity);
	public delegate void DeathHandler ();
	// Caso o valor chamado nesse evento seja maior que zero o character ganhou hp, caso seja menor que zero o character tomou dano e caso
	// seja = 0 o character se defendeu de um ataque
	public event HpChangeHandler onHpChange;
	public event MpChangeHandler onMpChange;
	public event DeathHandler onDeath;

	public void LoseHP(int quantity, int resistance) {
		int oldhp = hp;
		int damage = quantity - resistance > 0 ? quantity - resistance : 0;
		hp -= damage;
		if (hp < 0) {
			hp = 0;
			onDeath ();
		}
		onHpChange (hp - oldhp); 
	}

	public void GainHP(int quantity) {
		int oldhp = hp;
		hp += quantity;
		if (hp > maxhp)
			hp = maxhp;
		onHpChange (hp - oldhp);
	}

	public void LoseMP(int quantity) {
		int oldmp = mp;
		mp -= quantity;
		if (mp < 0)
			mp = 0;
		onMpChange (mp - oldmp);
	}

	public void GainMP(int quantity) {
		int oldmp = mp;
		mp += quantity;
		if (mp > maxmp)
			mp = maxmp;
		onMpChange (mp - oldmp);
	}	
}
