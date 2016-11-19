using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectSystem : MonoBehaviour {

	public delegate void EffectChangeHandler(Effect eff);

	public event EffectChangeHandler onEffectAdded;
	public event EffectChangeHandler onEffectRemoved;

	List<Effect> effects;

	public Color poisonDamageColor;
	// Use this for initialization
	void Start () {
		effects = new List<Effect> ();
	}

	public void AddEffect(Effect eff) {
		Effect temp = effects.Find ((Effect obj) => {
			return eff.effectName.Equals(obj.effectName);
		});

		if (temp != null)
		{
			eff.duration += temp.duration;
			effects.Remove (temp);
			temp.RemoveEffect ();
			eff.ApplyEffect (gameObject);
			effects.Add (eff);
		}
		else 
		{
			effects.Add (eff);
			eff.ApplyEffect (gameObject);
			if (onEffectAdded != null) {
				onEffectAdded (eff);
			}
		}
	}

	public void RemoveEffect(Effect eff) {
		effects.Remove (eff);
		eff.RemoveEffect ();
		if (onEffectRemoved != null) {
			onEffectRemoved (eff);
		}
	}

	public void RemoveEffect(string effectname) {
		Effect eff = effects.Find ((Effect obj) => {
			return obj.effectName.Equals(effectname);
		});
		if (eff != null) {
			RemoveEffect (eff);
		}
	}

	public List<Effect> getEffects() {
		return effects;
	}
}
