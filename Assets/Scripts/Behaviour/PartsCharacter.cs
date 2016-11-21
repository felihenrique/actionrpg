using UnityEngine;
using System.Collections;

public class PartsCharacter : MonoBehaviour {


	Animator animator;
	SpriteRenderer sprRenderer;
	Rigidbody2D rigid2D;
	Vector2 cachedDirection;
	Character baseCharacter;
	AttackSystem baseAttackSystem;

	bool isAttacking;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		sprRenderer = GetComponent<SpriteRenderer> ();
		rigid2D = GetComponentInParent<Rigidbody2D> ();
		baseCharacter = GetComponentInParent<Character> ();
		baseAttackSystem = GetComponentInParent<AttackSystem> ();
		baseAttackSystem.attackSwordInit += onAttackInit;
		baseAttackSystem.attackSwordEnd += onAttackEnd;
	}

	// Update is called once per frame
	void Update () {
		cachedDirection = baseCharacter.getCachedDirection ();
		animator.SetFloat ("speed_x", cachedDirection.x);
		animator.SetFloat ("speed_y", cachedDirection.y);
		animator.SetBool ("moving", !(rigid2D.velocity == Vector2.zero));
		animator.SetBool ("attacking", isAttacking);
		sprRenderer.color = Color.Lerp (sprRenderer.color, Color.white, 0.1f);
	}

	void onAttackInit() {
		isAttacking = true;
	}

	void onAttackEnd() {
		isAttacking = false;
	}
}
