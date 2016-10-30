using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(Animator))]
[RequireComponent(typeof(HealthMpSystem), typeof(EffectSystem))]
public class Character : MonoBehaviour {

	public float moveSpeed;
	public int maxHP;
	public int maxMP;
	public Color poisonDamageColor;

	Rigidbody2D rigid2D;
	//new Transform transform;
	Animator animator;
	HealthMpSystem healthmp;
	EffectSystem effectsystem;
	SpriteRenderer sprRenderer;

	Vector2 cachedDirection;
	Vector2 _input_velocity;
	// Use this for initialization
	void Start () {
		//transform = GetComponent<Transform> ();
		animator = GetComponent<Animator> ();
		rigid2D = GetComponent<Rigidbody2D> ();
		healthmp = GetComponent<HealthMpSystem> ();
		effectsystem = GetComponent<EffectSystem> ();
		sprRenderer = GetComponent<SpriteRenderer> ();
		_input_velocity = Vector2.zero;

		healthmp.AddMaxHP (maxHP);
		healthmp.AddMaxMP (maxMP);
	}

	// Update is called once per frame
	void Update () {
		if (_input_velocity != Vector2.zero) {
			cachedDirection = _input_velocity;
		}
		animator.SetFloat ("speed_x", cachedDirection.x);
		animator.SetFloat ("speed_y", cachedDirection.y);
		animator.SetBool ("moving", !(rigid2D.velocity == Vector2.zero));
		sprRenderer.color = Color.Lerp (sprRenderer.color, Color.white, 0.1f);

		if (Input.GetKeyDown(KeyCode.H)) {
			Envenenon effenv = new Envenenon ();
			effenv.damage = 3;
			effenv.effectName = "Envenenom I";
			effenv.interval = 3;
			effenv.duration = 15;
			effectsystem.AddEffect (effenv);

			Speed se = new Speed();
			se.duration = 10;
			se.effectName = "Speed I";
			se.speedMultiplier = 3;
			effectsystem.AddEffect(se);

			var effects = effectsystem.getEffects ();
			for (int i = 0; i < effects.Count; i++) {
				Debug.Log (effects [i].duration);
			} 
		} else if (Input.GetKeyDown(KeyCode.K)) {
			effectsystem.RemoveEffect ("Speed I");
			effectsystem.RemoveEffect ("Envenenom I");
		}
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
