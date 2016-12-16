using System;
using System.Collections;
using UnityEngine;

public abstract class Effect
{
	public Sprite sprite;
	public string effectName;
	public string description;
	public float duration;
	public abstract void ApplyEffect(GameObject obj);
	public abstract void RemoveEffect();
	private string spriteName;
}