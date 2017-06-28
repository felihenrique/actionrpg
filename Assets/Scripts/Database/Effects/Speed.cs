using System;
using UnityEngine;
using System.Collections;

public class Speed : Effect
{
	public float Multiplier;

	private MovementSystem movement;
	private new Animator animator;


	void Start()
	{
		movement = transform.parent.GetComponent<MovementSystem>();
		animator = transform.parent.GetComponent<Animator> ();
		Apply();
	}

	protected override void Apply ()
	{
		movement.Speed *= Multiplier;
		animator.speed *= Multiplier;
	}

	protected override void Remove ()
	{
		movement.Speed /= Multiplier;
		animator.speed /= Multiplier;
	}
}
