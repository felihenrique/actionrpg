using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HpMpExpShow : MonoBehaviour {

	public GameObject player;

	private HealthMpSystem hpmpSystem;
	private int old_hp;
	private int old_mp;
	private int old_exp;
	private RectTransform hp_bar;
	private RectTransform mp_bar;
	private RectTransform[] hp_parts;
	private RectTransform[] mp_parts;

	void Start () {
		hpmpSystem = player.GetComponent<HealthMpSystem> ();
		old_hp = (int)((hpmpSystem.getHP () / hpmpSystem.getMaxHP ()) * 10f) - 1;
		old_mp = (int)((hpmpSystem.getMP() / hpmpSystem.getMaxMP()) * 10f) - 1;
		hpmpSystem.hpChange += onHpChange;
		hpmpSystem.mpChange += onMpChange;
		hpmpSystem.maxHPChange += onHpChange;
		hpmpSystem.maxMPChange += onMpChange;
		hp_bar = GameObject.Find ("hp_bar").GetComponent<RectTransform>();
		mp_bar = GameObject.Find ("mp_bar").GetComponent<RectTransform>();
		hp_parts = hp_bar.GetComponentsInChildren<RectTransform> ();
		mp_parts = mp_bar.GetComponentsInChildren<RectTransform> ();
		System.Array.Copy (mp_parts, 1, mp_parts, 0, mp_parts.Length - 1);
		System.Array.Copy (hp_parts, 1, hp_parts, 0, hp_parts.Length - 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.J)) {
			hpmpSystem.LoseMP (12);
			print (hpmpSystem.getMP ());
		} 
		if (Input.GetKeyDown(KeyCode.K)) {
			hpmpSystem.GainMP (15);
			print (hpmpSystem.getMP ());
		}
	}

	void onHpChange(float amount) {
		var hp = (int)((hpmpSystem.getHP () / hpmpSystem.getMaxHP ()) * 10f) - 1;
		if (hp != old_hp) {
			old_hp = hp;
			for (int i = 0; i < 10; i++) {
				if (i > hp) {
					hp_parts [i].gameObject.SetActive (false);
				} else {
					hp_parts [i].gameObject.SetActive (true);
				}
			}
		}
	}

	void onMpChange(float amount) {
		var mp = (int)((hpmpSystem.getMP () / hpmpSystem.getMaxMP ()) * 10f) - 1;
		if (mp != old_mp) {
			old_mp = mp;
			for (int i = 0; i < 10; i++) {
				if (i > mp) {
					mp_parts [i].gameObject.SetActive (false);
				} else {
					mp_parts [i].gameObject.SetActive (true);
				}
			}
		}
	}
}
