using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackSystem : MonoBehaviour {

	private Animator animator;
	private new Transform transform;
	private MovementSystem movement;
	private float totalAttack;
	private float totalMagicAttack;
	private EquipmentSystem equipSystem;

	public delegate void attackedHandler();
	public event attackedHandler attackSwordInit;
	public event attackedHandler attackSwordEnd;

	void Start () {
		animator = GetComponent<Animator> ();
		transform = GetComponent<Transform> ();
		movement = GetComponent<MovementSystem> ();
		GetComponent<EquipmentSystem> ().EquipAdded += onEquipAdded;
		GetComponent<EquipmentSystem> ().EquipRemoved += onEquipRemoved;
	}

	public float getTotalAttack() {
		return totalAttack;
	}

	public float getTotalMagicalAttack() {
		return totalMagicAttack;
	}

	void onEquipAdded(Equipment equip) {
		if (equip.attack != 0) {
			totalAttack += equip.attack;
		}
		else if (equip.attackGainPercent != 0) {
			totalAttack *= 1 + equip.attackGainPercent;
		}

		if (equip.magicalAttack != 0) {
			totalMagicAttack += equip.magicalAttack;
		} 
		else if (equip.magicalAttackGainPercent != 0) {
			totalMagicAttack *= 1 + equip.magicalAttackGainPercent;
		}
	}

	void onEquipRemoved(Equipment equip) {
		if (equip.attack != 0) {
			totalAttack -= equip.attack;
		} 
		else if (equip.attackGainPercent != 0) {
			totalAttack *= 1 - equip.attackGainPercent;
		}

		if (equip.magicalAttack != 0) {
			totalMagicAttack -= equip.magicalAttack;
		} 
		else if (equip.magicalAttackGainPercent != 0) {
			totalMagicAttack *= 1 - equip.magicalAttackGainPercent;
		}
	}

	public void attackSwordEnded() 
	{
		animator.SetBool ("attacking", false);
		if (attackSwordEnd != null) {
			attackSwordEnd ();
		}
	}

	public void attackWithSword() 
	{
		if (animator.GetBool("attacking")) {
			return;
		}
		var direction1 = movement.getDirection4 ();
		var direction2 = Quaternion.Euler (0, 0, 30) * direction1;
		var direction3 = Quaternion.Euler (0, 0, -30) * direction1;
		var hits1 = Physics2D.RaycastAll (transform.position, direction1, 0.3f);
		var hits2 = Physics2D.RaycastAll (transform.position, direction2, 0.3f);
		var hits3 = Physics2D.RaycastAll (transform.position, direction3, 0.3f);

		HashSet<GameObject> setObjs = new HashSet<GameObject> ();
		for (int i = 0; i < hits1.Length; i++) {
			setObjs.Add (hits1 [i].collider.gameObject);
		}
		for (int i = 0; i < hits2.Length; i++) {
			setObjs.Add (hits2 [i].collider.gameObject);
		}
		for (int i = 0; i < hits3.Length; i++) {
			setObjs.Add (hits3 [i].collider.gameObject);
		}

		foreach (var obj in setObjs) {
			if (obj.name == gameObject.name) {
				continue;
			}
			obj.GetComponent<HealthMpSystem> ().LoseHP (totalAttack, obj.GetComponent<EquipmentSystem> ().getTotalPhysicalResist ());
		}

		animator.SetBool ("attacking", true);
		if (attackSwordInit != null) {
			attackSwordInit ();
		}
	}
}