using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(Animator))]
public class Character : MonoBehaviour {

	public float moveSpeed;

	Vector2 _input_velocity;
	Rigidbody2D rigid2D;
	new Transform transform;
	Animator animator;
	Vector2 cachedDirection;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
		animator = GetComponent<Animator> ();
		rigid2D = GetComponent<Rigidbody2D> ();
		_input_velocity = Vector2.zero;
	}

	// Update is called once per frame
	void Update () {
		if (_input_velocity != Vector2.zero) {
			cachedDirection = _input_velocity;
		}
		animator.SetFloat ("speed_x", cachedDirection.x);
		animator.SetFloat ("speed_y", cachedDirection.y);
		animator.SetBool ("moving", !(rigid2D.velocity == Vector2.zero));
	}

	void FixedUpdate() {
		rigid2D.velocity = _input_velocity * moveSpeed * Time.deltaTime;
	}
	public Vector2 InputVelocity {
		set {
			_input_velocity = value;
		}
	}
}
