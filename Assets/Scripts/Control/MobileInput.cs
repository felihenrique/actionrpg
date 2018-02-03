using UnityEngine;
using System.Collections;
/*
public class MobileInput : MonoBehaviour {
	private Character character;
	private Transform charTransform;
	// Use this for initialization
	void Start () {
		if (Application.platform != RuntimePlatform.Android) enabled = false;
		character = gameObject.GetComponent<Character> ();
		charTransform = gameObject.GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Vector2 pos = Camera.main.WorldToScreenPoint(charTransform.position);
			character.InputVelocity = (Input.GetTouch (0).position - pos).normalized;
		}
		else character.InputVelocity = Vector2.zero;
	}
}
*/