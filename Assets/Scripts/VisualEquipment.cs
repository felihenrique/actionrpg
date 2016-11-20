using UnityEngine;
using System.Collections;

public class VisualEquipment : MonoBehaviour {

	// Use this for initialization
	public Texture2D slash_base;
	public Texture2D weapon;
	public Texture2D slash_inuse;
	void Start () {
		StartCoroutine (EditTexture ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator EditTexture() {
		slash_inuse.SetPixels (slash_inuse.AlphaBlend (weapon).GetPixels ());
		slash_inuse.Apply ();
		yield return new WaitForEndOfFrame ();
	}
}
