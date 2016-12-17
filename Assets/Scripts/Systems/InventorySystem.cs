using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour {

	List<Item> itens = new List<Item>();

	public delegate void ItemHandler (Item item);
	public delegate void ItemUsedHandler (string name);
	public event ItemHandler onItemAcquired;
	public event ItemUsedHandler onItemUse;

	Item FindItem(Item item)
	{
		var it = itens.Find ((Item i) => {
			return i.itemName == item.itemName;
		});
		return it;
	}

	public void Acquire(Item item)
	{
		Item it = FindItem (item);
		if (it != null && it.stackable && it.stackSize < it.stackMaxSize) {
			it.stackSize += item.stackSize;
			it.stackSize = Mathf.Clamp (it.stackSize, 0, it.stackMaxSize);
			if (onItemAcquired != null) {
				onItemAcquired (item);
			}
			return;
		}
		if (onItemAcquired != null) {
			onItemAcquired (item);
		}
		itens.Add (item);
	}

	public void Remove(Item item)
	{
		Item it = FindItem (item);
		if (it == null)
			return;
		if (it.stackSize == 1) {
			itens.Remove (it);
			Destroy (it.gameObject);
		}
		else
			it.stackSize--;
	}

	public void RemoveAll(Item item)
	{
		Item it = FindItem (item);
		if (it == null)
			return;
		itens.Remove (it);
		Destroy (it.gameObject);
	}

	public void UseItem(Item item)
	{
		Item it = FindItem (item);
		if (it == null)
			return; 
		it.Use (gameObject);
		it.stackSize--;
		if (onItemUse != null) {
			onItemUse (item.name);
		}
		if (it.stackSize == 0) {
			Destroy (it.gameObject);
		}
	}

	public void UseItemOn(Item item, GameObject obj)
	{
		Item it = FindItem (item);
		if (it == null)
			return;
		it.Use (obj);
		it.stackSize--;
		if (onItemUse != null) {
			onItemUse (item.name);
		}
		if (it.stackSize == 0)
			Destroy (it.gameObject);
	}
}
