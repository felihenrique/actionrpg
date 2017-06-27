using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour {
	[SerializeField]
	private float speed = 0.5f;
	private Animator animator;

	public delegate void SpeedChangeHandler();
	public event SpeedChangeHandler SpeedChanged;

	public float Speed { 
		get { return speed; } 
		set {
			SpeedChanged?.Invoke ();
			speed = value;
		}
	}

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	public Vector2 getDirection4() {
		Vector2 cachedDirection = new Vector2 (animator.GetFloat ("speed_x"), animator.GetFloat ("speed_y"));
		if (cachedDirection == Vector2.zero) {
			return Vector2.down;
		}
		if (Mathf.Abs(cachedDirection.x) > Mathf.Abs(cachedDirection.y)) {
			return cachedDirection.x > 0 ? Vector2.right : Vector2.left;
		} else {
			return cachedDirection.y > 0 ? Vector2.up : Vector2.down; 
		}
	}
}
