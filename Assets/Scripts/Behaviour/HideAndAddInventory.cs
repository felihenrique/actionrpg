using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Itens;
using RPG.Systems;

namespace RPG.Behaviour
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class HideAndAddInventory : MonoBehaviour
    {
        SpriteRenderer sprRenderer;
        Item item;
        void Start()
        {
            sprRenderer = GetComponent<SpriteRenderer>();
            item = GetComponent<Item>();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag != "Player")
                return;
            var invSystem = collider.gameObject.GetComponent<InventorySystem>();
            bool added = invSystem.Add(item, 1);
            if (added)
            {
                sprRenderer.enabled = false;
                Destroy(this);
            }
            else
            {
                print("Não foi possível adicionar o item ao inventário");
            }
        }
    }   
}