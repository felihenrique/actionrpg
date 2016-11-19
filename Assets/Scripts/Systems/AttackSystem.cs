using UnityEngine;
using System.Collections;

public class AttackSystem : MonoBehaviour {

	Animator animator;
	bool attackingSword;

	public delegate void attackedHandler();

	public event attackedHandler attackSwordInit;
	public event attackedHandler attackSwordEnd;
	// Use this for initialization
	void Start () {
		attackingSword = false;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("attacking", attackingSword);
	}

	public void attackSwordEnded() {
		attackingSword = false;
		if (attackSwordEnd != null) {
			attackSwordEnd ();
		}
	}

	public void attackWithSword() {
		attackingSword = true;
		if (attackSwordInit != null) {
			attackSwordInit ();
		}
	}
}
