using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class HideAndAddInventory : MonoBehaviour {

	// Use this for initialization
	SpriteRenderer sprRenderer;
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
        InventorySystem invSystem = collider.gameObject.GetComponent<InventorySystem> ();
		bool added = invSystem.Add (item, 1);
        if (!added)
        {
            return;
        }
		Destroy (sprRenderer);
		Destroy (this);
	}
}
