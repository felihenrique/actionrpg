using System;
using System.Collections;
using UnityEngine;

public abstract class Effect : ISerializationCallbackReceiver
{
	[NonSerialized]
	public Sprite sprite;
	public string effectName;
	public string description;
	public float duration;
	public abstract void ApplyEffect(GameObject obj);
	public abstract void RemoveEffect();
	[SerializeField]
	private string spriteName;

	public void OnAfterDeserialize()
	{
		ItemDatabase database = GameObject.Find ("ItemDatabase").GetComponent<ItemDatabase>();
		if (database == null) {
			return;
		}			
		Sprite spr = System.Array.Find (database.sprites, (Sprite s) => {
			return s.name == spriteName;
		});
		if (spr != null) {
			sprite = spr;
		}
			
	}

	public void OnBeforeSerialize()
	{
		spriteName = sprite.name;
	}
}