using System;
using UnityEngine;
using System.Collections;

public class Speed : Effect
{
	public float speedMultiplier;
	private MovementSystem movement;
	private EffectSystem esystem;

	public override void ApplyEffect(GameObject obj)
	{
		movement = obj.GetComponent<MovementSystem>();
		esystem = obj.GetComponent<EffectSystem>();
		movement.SetSpeedMultiplier(speedMultiplier);
		esystem.StartCoroutine(DoSpeedEffect());
	}

	public override void RemoveEffect()
	{
		duration = 0;
	}

	IEnumerator DoSpeedEffect()
	{
		while (duration > 0) {
			duration -= Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		movement.SetSpeedMultiplier (0);
		esystem.RemoveEffect(this);
	}
}
