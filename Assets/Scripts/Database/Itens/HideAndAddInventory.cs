using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class HideAndAddInventory : MonoBehaviour {

	// Use this for initialization
	SpriteRenderer sprRenderer;
	InventorySystem invSystem;
	Item item;
	void Start () {
		sprRenderer = GetComponent<SpriteRenderer> ();
		item = GetComponent<Item> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag != "Player")
			return;
		invSystem = collider.gameObject.GetComponent<InventorySystem> ();
		sprRenderer.enabled = false;
		invSystem.Acquire (item);
	}
}
