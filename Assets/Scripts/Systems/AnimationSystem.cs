using UnityEngine;
using System.Collections;
using Prime31;

public class AnimationSystem : MonoBehaviour {

	private Animator animator;
	private CharacterController2D characterController;
	void Start () {
		animator = GetComponent<Animator> ();
		characterController = GetComponent<CharacterController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (characterController.velocity != Vector2.zero) {
			animator.SetFloat ("speed_x", characterController.velocity.x);
			animator.SetFloat ("speed_y", characterController.velocity.y);
			animator.SetBool ("moving", true);
		} else {
			animator.SetBool ("moving", false);
		}

	}
}
