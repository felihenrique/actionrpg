using System;
using System.Collections;
using UnityEngine;

public class Envenenon : Effect
{
	public float Interval; // em segundos
	public int Damage;

    private Attributes attr;
	private float accumTime;

	void Start()
	{
        attr = transform.parent.GetComponent<Attributes> ();
	}

	protected override void Update ()
	{
		base.Update ();

		accumTime += Time.deltaTime;
		if (accumTime >= Interval) {
			accumTime = 0;
            attr.Add(VariableAttr.HP, -Damage);
		}
	}
}