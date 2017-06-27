using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour {
	private float totalPhysicalResistance;
	private float totalMagicalResistance;
	private float totalAttack;
	private float totalMagicAttack;
	private float totalDamageMultiplier;

	public delegate void AttrChangeHandler(float delta);
	public delegate void DmgMultHandler (float delta);
	public event AttrChangeHandler PhysicalResistanceChanged;
	public event AttrChangeHandler MagicalResistanceChanged;
	public event AttrChangeHandler AttackChanged;
	public event AttrChangeHandler MagicAttackChanged;
	public event DmgMultHandler DamageMultiplierChanged;

	public float PhysicalResistance {
		get { return totalPhysicalResistance; }
	}
	public void ChangePhysicalResistance(float delta) {
		totalPhysicalResistance += delta;
		PhysicalResistanceChanged?.Invoke(delta);
	}

	public float MagicalResistance {
		get { return totalMagicalResistance; }
	}
	public void ChangeMagicalResistance(float delta) {
		totalMagicalResistance += delta;
		MagicalResistanceChanged?.Invoke(delta);
	}

	public float TotalAttack {
		get { return totalAttack; }
	}
	public void ChangeAttack(float delta) {
		totalAttack += delta;
		AttackChanged?.Invoke (delta);
	}

	public float MagicAttack {
		get { return totalMagicAttack; }
	}
	public void ChangeMagicAttack(float delta) {
		totalMagicAttack += delta;
		MagicAttackChanged?.Invoke (delta);
	}

	public float DamageMultiplier {
		get { return totalDamageMultiplier; }
	}
	public void ChangeDamageMultiplier(float delta) {
		totalDamageMultiplier += delta;
		DamageMultiplierChanged?.Invoke (delta);
	}
}