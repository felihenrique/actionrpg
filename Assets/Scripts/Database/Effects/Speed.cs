using System;
using UnityEngine;
using System.Collections;

public class Speed : Effect
{
	public float Multiplier;

    private Character character;
	private Animator animator;


	void Start()
	{
        character = transform.parent.GetComponent<Character>();
		animator = transform.parent.GetComponent<Animator> ();
		Apply();
	}

	protected override void Apply ()
	{
        character.Speed *= Multiplier;
		animator.speed *= Multiplier;
	}

	protected override void Remove ()
	{
        character.Speed /= Multiplier;
		animator.speed /= Multiplier;
	}
}
