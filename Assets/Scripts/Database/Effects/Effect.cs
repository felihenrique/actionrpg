using System;
using UnityEngine;

public abstract class Effect
{
	public int icon_sprite_id;
	public string effectName;
	public string description;
	public float duration;
	public abstract void ApplyEffect(GameObject obj);
	public abstract void RemoveEffect();

	protected float timePassed;
}