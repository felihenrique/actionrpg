using System;
using System.Collections;
using UnityEngine;

public class Envenenon : Effect
{
	public float interval; // em segundos
	public int damage;

	private HealthMpSystem hpmpSystem;
	private EffectSystem esystem;

	public override void ApplyEffect (GameObject obj)
	{
		hpmpSystem = obj.GetComponent<HealthMpSystem> ();
		esystem = obj.GetComponent<EffectSystem> ();
		esystem.StartCoroutine (DoVenenomEffect());
	}

	public override void RemoveEffect ()
	{
		duration = 0;
	}

	IEnumerator DoVenenomEffect() {
		while (duration > 0) {
			hpmpSystem.LoseHP (damage, 0);
			duration -= interval;
			yield return new WaitForSeconds (interval);
		}
		esystem.RemoveEffect (this);
	}
}