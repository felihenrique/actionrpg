using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class HideAndAddInventory : MonoBehaviour
{

    public float fadingVelocity = 0.2f;
    // Use this for initialization
    SpriteRenderer sprRenderer;
    Item item;
    bool fading = false;
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        item = GetComponent<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fading)
            return;
        var color = sprRenderer.color;
        sprRenderer.color = new Color(color.r, color.b, color.g, fadingVelocity * Time.deltaTime);
        if (sprRenderer.color.a <= 0)
        {
            Destroy(sprRenderer);
            Destroy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player")
            return;
        InventorySystem invSystem = collider.gameObject.GetComponent<InventorySystem>();
        bool added = invSystem.Add(item, 1);
        if (!added)
        {
            return;
        }
        fading = true;
    }
}
