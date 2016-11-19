using System;
using System.Collections;
using UnityEngine;

public class Envenenon : Effect
{
	public float interval; // em segundos
	public int damage;

	private HealthMpSystem hpmpSystem;
	private EffectSystem esystem;
	private SpriteRenderer sprRenderer;
	private Character character;

	public override void ApplyEffect (GameObject obj)
	{
		hpmpSystem = obj.GetComponent<HealthMpSystem> ();
		esystem = obj.GetComponent<EffectSystem> ();
		sprRenderer = obj.GetComponent<SpriteRenderer> ();
		character = obj.GetComponent<Character> ();
		esystem.StartCoroutine (DoVenenomEffect());
	}

	public override void RemoveEffect ()
	{
		duration = 0;
	}

	IEnumerator DoVenenomEffect() {
		while (duration > 0) {
			sprRenderer.color = esystem.poisonDamageColor;
			hpmpSystem.LoseHP (damage, 0);
			duration -= interval;
			yield return new WaitForSeconds (interval);
		}
		esystem.RemoveEffect (this);
	}
}