using System;
using UnityEngine;

public abstract class Effect
{
	public int icon_sprite_id;
	public string name;
	public string description;
	public float duration;
	public abstract void ApplyEffect(GameObject obj);
	public abstract void RemoveEffect();

	public virtual void Update() {
		if (timePassed >= duration) {
			RemoveEffect ();
			complete = true;
			return;
		}
		timePassed += Time.deltaTime;
	}

	public bool isComplete() { return complete; }

	protected float timePassed;
	protected bool applied;
	protected bool complete;
}