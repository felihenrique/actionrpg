using System;
using UnityEngine;
using System.Collections;

public class Speed : Effect
{
	public float speedMultiplier;
	private Character character;
	private EffectSystem system;

	public override void ApplyEffect(GameObject obj)
	{
		character = obj.GetComponent<Character>();
		system = obj.GetComponent<EffectSystem>();
		character.moveSpeed *= speedMultiplier;
		system.StartCoroutine(DoSpeedEffect());
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
		character.moveSpeed /= speedMultiplier;
		system.RemoveEffect(this);
	}
}
