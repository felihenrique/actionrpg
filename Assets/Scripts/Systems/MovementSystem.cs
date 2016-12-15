using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour {


	private float speedMultiplier = 1;
	private Animator animator;

	public float speedLimit = 10;
	public float speed = 2;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	public delegate void SpeedChangeHandler(float quant);

	public event SpeedChangeHandler SpeedChanged;

	public void AddSpeed(float quantity)
	{
		speed += quantity;
		speed = Mathf.Clamp (speed, 0, speedLimit);
		if (SpeedChanged != null)
			SpeedChanged (quantity);
	}

	public void ReduceSpeed(float quantity)
	{
		speed -= quantity;
		speed = Mathf.Clamp (speed, 0, speedLimit);
		if (SpeedChanged != null)
			SpeedChanged (quantity);
	}

	public void SetSpeedMultiplier(float quantity)
	{
		speedMultiplier = quantity;
		if (SpeedChanged != null)
			SpeedChanged ((quantity - 1) * speed);
	}

	public float Speed 
	{
		get { return speed * speedMultiplier; }
		set { speed = value; }
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
