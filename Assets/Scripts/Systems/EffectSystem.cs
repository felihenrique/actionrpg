using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectSystem : MonoBehaviour {

	public delegate void EffectChangeHandler(Effect eff);

	public event EffectChangeHandler EffectAdded;
	public event EffectChangeHandler EffectRemoved;

	List<Effect> effects;
	// Use this for initialization
	void Start () {
		effects = new List<Effect> ();
	}

	public void AddEffect(Effect eff) {
		Effect temp = effects.Find ((Effect obj) => {
			return eff.effectName.Equals(obj.effectName);
		});

		if (temp != null) temp.duration += eff.duration;
		else 
		{
			effects.Add (eff);
			eff.ApplyEffect (gameObject);
			if (EffectAdded != null) EffectAdded (eff);
		}
	}

	public void RemoveEffect(Effect eff) {
		effects.Remove (eff);
		eff.RemoveEffect ();
		if (EffectRemoved != null) EffectRemoved (eff);
	}

	public void RemoveEffect(string effectname) {
		Effect eff = effects.Find ((Effect obj) => {
			return obj.effectName.Equals(effectname);
		});
		if (eff != null) RemoveEffect (eff);
	}

	public List<Effect> EffectList {
		get { return effects; }
	}
}
