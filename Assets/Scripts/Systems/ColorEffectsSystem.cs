using UnityEngine;
using System.Collections;

public class ColorEffectsSystem : MonoBehaviour {

	public Color damageColor;
	public Color envenenomColor;

	private SpriteRenderer[] sprRenderers;
	private HealthMpSystem hpmpSystem;

	void Start () {
		sprRenderers = GetComponentsInChildren<SpriteRenderer> ();
		hpmpSystem = GetComponent<HealthMpSystem> ();

		hpmpSystem.hpChange += onDamage;
	}

	void onDamage(float quant) {
		for (int i = 0; i < sprRenderers.Length; i++) {
			if (sprRenderers[i].gameObject.activeSelf) {
				sprRenderers [i].color = damageColor;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
