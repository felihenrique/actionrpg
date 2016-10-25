using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item {
	public enum ItemType 
	{
		Support, Armor, Weapon, Food, Acessory
	}
	public int id;
	public string name;
	public string description;
	public string animation_name;
	public int price;
	public bool consumable;
	public ItemType type;
	public Dictionary<string, int> properties; // essa variavel depende do item. Ex: para arma existe uma propriedade chamada "ataque"
	public override int GetHashCode ()
	{
		return id;
	}
}
