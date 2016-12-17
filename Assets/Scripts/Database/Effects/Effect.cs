using System;
using System.Collections;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
	public Sprite sprite;
	public string effectName;
	public string description;
	public float duration;
	public abstract void ApplyEffect();
	public abstract void RemoveEffect();
	private string spriteName;

	void Update()
	{
		if (duration <= 0) {
			RemoveEffect ();
			Destroy (gameObject);
		}			
	}
}