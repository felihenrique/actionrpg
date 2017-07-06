using System;
using System.Collections;
using UnityEngine;

public class Envenenon : Effect
{
	public float Interval; // em segundos
	public int Damage;

	private HealthSystem hpSys;
	private float accumTime;

	void Start()
	{
		hpSys = transform.parent.GetComponent<HealthSystem> ();
	}

	protected override void Update ()
	{
		base.Update ();

		accumTime += Time.deltaTime;
		if (accumTime >= Interval) {
			accumTime = 0;
			hpSys.Hp -= Damage;
		}
	}
}