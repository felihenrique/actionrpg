using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PCInput : MonoBehaviour {
    private Character character;
	private new Transform transform;
	private new Rigidbody2D rigidbody2D;
	private new Camera camera;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
        character = GetComponent<Character> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 mousePos = Input.mousePosition;
		Vector2 charPos = camera.WorldToScreenPoint (transform.position);
		float distance = Vector2.Distance (mousePos, charPos);
		if (Input.GetKey (KeyCode.Mouse0) && distance > 5f) {
            rigidbody2D.velocity = (mousePos - charPos).normalized * character.Speed;
		} else {
			rigidbody2D.velocity = new Vector2(0, 0);
		}
	}
}