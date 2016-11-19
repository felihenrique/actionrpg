using UnityEngine;
using System.Collections;
using ActionRPGEngine.VectorUtils;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PCInput : MonoBehaviour {
	private Character character;
	private Transform charTransform;
	private Button attackButton;
	private AttackSystem attackSystem;
	private bool attacking;
	// Use this for initialization
	void Start () {
		if (Application.platform != RuntimePlatform.WindowsPlayer && Application.platform != RuntimePlatform.WindowsEditor) 
			enabled = false;
		character = GetComponent<Character> ();
		charTransform = GetComponent<Transform> ();
		attackSystem = GetComponent<AttackSystem> ();
		attackSystem.attackSwordInit += onAttackInit;
		attackSystem.attackSwordEnd += onAttackEnd;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mousePos = Input.mousePosition;
		Vector2 charPos = Camera.main.WorldToScreenPoint (charTransform.position);
		Vector2 mouseView = Camera.main.ScreenToViewportPoint (mousePos);
		if (Input.GetKey(KeyCode.Mouse0) && (Vector3.Distance(charPos, mousePos) > 15f) &&  mouseView.x < 0.9 && !attacking)
			character.InputVelocity = (mousePos - charPos).normalized;
		else character.InputVelocity = Vector2.zero;
	}

	void onAttackInit() {
		attacking = true;
	}

	void onAttackEnd() {
		attacking = false;
	}
}