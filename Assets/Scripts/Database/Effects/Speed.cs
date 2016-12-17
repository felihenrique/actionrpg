using System;
using UnityEngine;
using System.Collections;

public class Speed : Effect
{
	public float speedMultiplier;
	private MovementSystem movement;


	void Start()
	{
		movement = transform.parent.GetComponent<MovementSystem>();
		ApplyEffect ();
	}

	public override void ApplyEffect()
	{
		movement.SetSpeedMultiplier(speedMultiplier);
		StartCoroutine(DoSpeedEffect());
	}

	public override void RemoveEffect()
	{
		duration = 0;
		movement.SetSpeedMultiplier (1);
	}

	IEnumerator DoSpeedEffect()
	{
		while (duration > 0) {
			duration -= Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
	}
}
