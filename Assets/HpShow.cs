using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpShow : MonoBehaviour {

	public HealthMpSystem hpmp;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = "HP: " + hpmp.getHP().ToString() + "/" + hpmp.getMaxHP().ToString();
		hpmp.hpChange += hpChanged;
		hpmp.maxHPChange += hpChanged;
	}

	void hpChanged(int quantity) {
		text.text = "HP: " + hpmp.getHP().ToString() + "/" + hpmp.getMaxHP().ToString();
	}
}
