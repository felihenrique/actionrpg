using System;
using UnityEngine;
using System.Collections;

public class Speed : Effect
{
	public float Multiplier;

	private MovementSystem movement;


	void Start()
	{
		movement = transform.parent.GetComponent<MovementSystem>();
		Apply();
	}

	protected override void Apply ()
	{
		movement.Speed *= Multiplier;
	}

	protected override void Remove ()
	{
		movement.Speed /= Multiplier;
	}
}
