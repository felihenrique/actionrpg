using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HpSystem), typeof(SpriteRenderer))]
public class ColorEffectsSystem : MonoBehaviour {

	public Color DamageColor;
	public Color EnvenenomColor;

	private SpriteRenderer sprRenderer;
	private HpSystem hpSys;

	void Start () {
		sprRenderer = GetComponent<SpriteRenderer> ();
		hpSys = GetComponent<HpSystem> ();
		hpSys.HpChanged += OnHpChange;
	}

	void OnHpChange(float delta) {
		if (delta < 0)
			return;
		
		var enven = GetComponentInChildren<Envenenon> ();

		if (enven == null)
			sprRenderer.color = DamageColor;
		else
			sprRenderer.color = EnvenenomColor;
	}
	
	// Update is called once per frame
	void Update () {
		sprRenderer.color = Color.Lerp (sprRenderer.color, Color.white, 0.1f);
	}
}
