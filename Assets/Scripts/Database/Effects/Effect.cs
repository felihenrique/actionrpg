using System;
using System.Collections;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
	public delegate void EndedHandler (Effect eff);
	public event EndedHandler Ended;

	protected virtual void Apply() {}
	protected virtual void Remove() {}
	public Sprite Sprite;
	public string Name;
	public string Description;
	public float Duration;

	public virtual void Stop () {
		Duration = 0;
		Remove ();
	}

	protected virtual void Update() {
		if (Duration <= 0) {
			Remove ();
			Ended?.Invoke (this);
			enabled = false;
			return;
		}
		Duration -= Time.deltaTime;
	}
}