﻿using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour {
	[SerializeField]
	private float speed = 0.5f;
	private Animator animator;

	public delegate void SpeedChangeHandler();
	public event SpeedChangeHandler SpeedChanged;

	public float Speed { 
		get { return speed; } 
		set {
			SpeedChanged?.Invoke ();
			speed = value;
		}
	}

	void Start()
	{
		animator = GetComponent<Animator> ();
	}
}
