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
		timePassed = 0;
		hpmpSystem = obj.GetComponent<HealthMpSystem> ();
		esystem = obj.GetComponent<EffectSystem> ();
		sprRenderer = obj.GetComponent<SpriteRenderer> ();
		character = obj.GetComponent<Character> ();

		esystem.StartCoroutine (DoEffect());
	}

	public override void RemoveEffect ()
	{
		
	}

	IEnumerator DoEffect() {
		sprRenderer.color = character.poisonDamageColor;
		hpmpSystem.LoseHP (damage, 0);
		yield return new WaitForSeconds (interval);
		timePassed += interval;
		if (timePassed >= duration) {
			esystem.RemoveEffect (this);
		} 
		else {
			esystem.StartCoroutine (DoEffect());
		}
	}
}