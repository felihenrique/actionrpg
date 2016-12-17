using UnityEngine;
using System.Collections;
using ActionRPGEngine.VectorUtils;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PCInput : MonoBehaviour {
	private CharacterController2D character;
	private MovementSystem movement;
	private new  Transform transform;
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController2D> ();
		transform = GetComponent<Transform> ();
		movement = GetComponent<MovementSystem> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 mousePos = Input.mousePosition;
		Vector2 charPos = Camera.main.WorldToScreenPoint (transform.position);
		float distance = Vector2.Distance (mousePos, charPos);
		if (Input.GetKey (KeyCode.Mouse0) && distance > 5f) {
			character.velocity = (mousePos - charPos).normalized * movement.Speed;
		} else {
			character.velocity = Vector2.zero;
		}
	}
}