using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof( Rigidbody2D ) )]
public class CharacterController2D : MonoBehaviour
{
	private new Rigidbody2D rigidbody2D;
	private new Transform transform;

	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D> ();
		transform = GetComponent<Transform> ();
	}
	[SerializeField]
	public Vector2 velocity {
		get { return rigidbody2D.velocity; }
		set { rigidbody2D.velocity = value; }
	}
}
