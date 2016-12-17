using UnityEngine;
using System.Collections;

public class ColorEffectsSystem : MonoBehaviour {

	public Color damageColor;
	public Color envenenomColor;

	private SpriteRenderer sprRenderer;
	private HpMpSystem hpmpSystem;

	void Start () {
		sprRenderer = GetComponent<SpriteRenderer> ();
		hpmpSystem = GetComponent<HpMpSystem> ();
		hpmpSystem.hpChange += onDamage;
	}

	void onDamage(float quant) {
		sprRenderer.color = damageColor;
	}
	
	// Update is called once per frame
	void Update () {
		sprRenderer.color = Color.Lerp (sprRenderer.color, Color.white, 0.1f);
	}
}
