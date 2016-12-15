using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;


namespace Prime31 {

	[RequireComponent(typeof( Rigidbody2D ) )]
	public class CharacterController2D : MonoBehaviour
	{
		private Rigidbody2D rigidbody2D;
		private new Transform transform;
		private Vector2 toMove;

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
}