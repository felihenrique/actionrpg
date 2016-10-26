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

	void Update () {
		for (int i = 0; i < effects.Count; i++) {
			if (effects[i].isComplete()) {
				effects.RemoveAt (i);
				i--;
				return;
			}
			effects [i].Update ();
		}
	}

	public void AddEffect(Effect eff) {
		effects.Add (eff);
		onEffectAdded (eff);
	}

	public void RemoveEffect(Effect eff) {
		effects.Remove (eff);
		onEffectRemoved (eff);
	}
}
