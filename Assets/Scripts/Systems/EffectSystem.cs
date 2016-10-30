using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectSystem : MonoBehaviour {

	public delegate void EffectChangeHandler(Effect eff);

	public event EffectChangeHandler onEffectAdded;
	public event EffectChangeHandler onEffectRemoved;

	List<Effect> effects;
	// Use this for initialization
	void Start () {
		effects = new List<Effect> ();
	}

	public void AddEffect(Effect eff) {
		Effect temp = effects.Find (delegate(Effect e) {
			return e.GetType() == eff.GetType();
		});
		if (temp != null && temp.effectName == eff.effectName) {
			temp.duration += eff.duration;
		} else {
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

	public List<Effect> getEffects() {
		return effects;
	}
}
