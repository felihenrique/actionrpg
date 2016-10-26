using System;
using UnityEngine;
using UnityEngine.Scripting;

public class Envenenon : Effect
{
	public float interval; // em segundos
	public int damage;

	private HealthMpSystem hpmpSystem;

	public override void ApplyEffect (GameObject obj)
	{
		timePassed = 0;
		hpmpSystem = obj.GetComponent<HealthMpSystem> ();
	}

	public override void RemoveEffect ()
	{
		complete = true;
	}

	public override void Update ()
	{
		if (timePassed >= duration) {
			RemoveEffect ();
			complete = true;
			return;
		}
		if (timePassed >= interval) {
			timePassed = 0;
			hpmpSystem.LoseHP (damage, 0);
		}
		timePassed += Time.deltaTime;
	}
}