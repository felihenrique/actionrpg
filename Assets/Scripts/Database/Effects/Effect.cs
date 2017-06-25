using System;
using System.Collections;
using UnityEngine;

public abstract class Effect : MonoBehaviour, IPoolable
{
	public delegate void EndedHandler (Effect eff);
	public event EndedHandler Ended;

	protected abstract void Apply();
	protected abstract void Remove();
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