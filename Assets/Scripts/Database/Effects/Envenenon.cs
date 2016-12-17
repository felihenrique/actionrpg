using System;
using System.Collections;
using UnityEngine;

public class Envenenon : Effect
{
	public float interval; // em segundos
	public int damage;
	private HpMpSystem hpmpSystem;

	void Start()
	{
		hpmpSystem = transform.parent.GetComponent<HpMpSystem> ();
		ApplyEffect ();
	}

	public override void ApplyEffect ()
	{
		StartCoroutine (DoVenenomEffect ());
	}

	public override void RemoveEffect ()
	{
		duration = 0;
	}

	IEnumerator DoVenenomEffect() {
		while (duration > 0) {
			hpmpSystem.LoseHP (damage, 0);
			duration -= interval;
			print (hpmpSystem.HP);
			yield return new WaitForSeconds (interval);
		}
	}
}