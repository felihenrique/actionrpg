using UnityEngine;
using System.Collections;

public class AnimationSystem : MonoBehaviour {

	private Animator animator;
	private new Rigidbody2D rigidbody2D;
	void Start () {
		animator = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float velocity = rigidbody2D.velocity.magnitude;
		if (velocity > 0.01f) {
			animator.SetFloat ("speed_x", rigidbody2D.velocity.x);
			animator.SetFloat ("speed_y", rigidbody2D.velocity.y);
			animator.SetBool ("moving", true);
		} else {
			animator.SetBool ("moving", false);
		}

	}
}
