using UnityEngine;
using System.Collections;
using ActionRPGEngine.VectorUtils;

public class PCInput : MonoBehaviour {
	private Character character;
	private Transform charTransform;
	// Use this for initialization
	void Start () {
		if (Application.platform != RuntimePlatform.WindowsPlayer && Application.platform != RuntimePlatform.WindowsEditor) 
			enabled = false;
		character = GetComponent<Character> ();
		charTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mousePos = Input.mousePosition;
		Vector2 charPos = Camera.main.WorldToScreenPoint (charTransform.position);
		if (Input.GetKey(KeyCode.Mouse0) && (Vector3.Distance(charPos, mousePos) > 15f))
			character.InputVelocity = (mousePos - charPos).normalized;
		else character.InputVelocity = Vector2.zero;
	}
}
