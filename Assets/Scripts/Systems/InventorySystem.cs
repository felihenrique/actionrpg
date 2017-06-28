using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour {

	Item[] itens = new Item[30];

	public delegate void ItemHandler (Item item);

	public Item Get(int id)
	{
		if (id < 0 || id > itens.Length)
			return null;
		return itens [id];
	}

	public Item[] GetAll()
	{
		return itens;
	}

	public void AddQuantity(int id, int quantity)
	{
		if (id < 0 || id > itens.Length)
			return;
		Item i = itens [id];
		if (i == null)
			return;
		itens [id].Quantity += quantity;
	}

	public void Add(int id, Item item)
	{
		if (id < 0 || id > itens.Length)
			return;
		itens [id] = item;
	}

	public int? FirstEmpty()
	{
		for (int i = 0; i < itens.Length; i++) {
			if (itens [i] == null)
				return i;
		}
		return null;
	}

	public void Remove(int id)
	{
		itens [id] = null;
	}

	public void Expand(int quantity)
	{
		System.Array.Resize (ref itens, itens.Length + quantity);
	}

	public void UseItem(int id, GameObject otherObj=null)
	{
		if (id < 0 || id > itens.Length)
			return;
		Item i = itens [id];
		if (i == null)
			return;
		i.Use (otherObj ?? gameObject);
		i.Quantity--;
		if (i.Quantity == 0)
			Destroy (i.gameObject);
	}
}
