using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(Animator))]
[RequireComponent(typeof(HealthMpSystem), typeof(EffectSystem))]
public class Character : MonoBehaviour {

	public float moveSpeed;
	public int maxHP;
	public int maxMP;

	Rigidbody2D rigid2D;
	//new Transform transform;
	Animator animator;
	HealthMpSystem healthmp;
	SpriteRenderer sprRenderer;
	Color sprColor;

	Vector2 cachedDirection;
	Vector2 _inputVelocity;
	// Use this for initialization
	void Start () {
		//transform = GetComponent<Transform> ();
		animator = GetComponent<Animator> ();
		rigid2D = GetComponent<Rigidbody2D> ();
		healthmp = GetComponent<HealthMpSystem> ();
		sprRenderer = GetComponent<SpriteRenderer> ();
		_inputVelocity = Vector2.zero;
		healthmp.AddMaxHP (maxHP);
		healthmp.AddMaxMP (maxMP);
		sprColor = sprRenderer.color;
	}

	// Update is called once per frame
	void Update () {
		if (_inputVelocity != Vector2.zero) {
			cachedDirection = _inputVelocity;
		}
		animator.SetFloat ("speed_x", cachedDirection.x);
		animator.SetFloat ("speed_y", cachedDirection.y);
		animator.SetBool ("moving", !(rigid2D.velocity == Vector2.zero));
		sprRenderer.color = Color.Lerp (sprRenderer.color, sprColor, 0.1f);
	}

	public Vector2 getCachedDirection() {
		return cachedDirection;
	}

	public Vector2 getDirection4() {
		if (cachedDirection == Vector2.zero) {
			return Vector2.down;
		}
		if (Mathf.Abs(cachedDirection.x) > Mathf.Abs(cachedDirection.y)) {
			return cachedDirection.x > 0 ? Vector2.right : Vector2.left;
		} else {
			return cachedDirection.y > 0 ? Vector2.up : Vector2.down; 
		}
	}

	void FixedUpdate() {
		rigid2D.velocity = _inputVelocity * moveSpeed * Time.deltaTime;
	}

	public Vector2 InputVelocity {
		set {
			_inputVelocity = value;
		}
	}
}
