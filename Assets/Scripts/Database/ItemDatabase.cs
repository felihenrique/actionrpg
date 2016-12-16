using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

public class ItemDatabase {
	private static Dictionary<string, Item> itens = new Dictionary<string, Item>();
	private const string databasePath = "Assets/Scripts/Database/itens.data";

	public static void Load()
	{
		FileStream file = new FileStream (databasePath, FileMode.Open);
		BinaryFormatter formatter = new BinaryFormatter ();
		int tam = (int)formatter.Deserialize (file);
		for (int i = 0; i < tam; i++) {
			Item it = formatter.Deserialize (file) as Item;
			itens [it.itemName] = it;
		}
		file.Close ();
	}

	public static void Add(Item it)
	{
		itens [it.itemName] = it;
	}

	public static void Clear()
	{
		itens.Clear ();
	}

	public static Item Acquire(string name)
	{
		Item temp1;
		if (!itens.TryGetValue (name, out temp1))
			return null;
		Item temp2 = (Item)temp1.Clone ();
		temp2.timeAcquired = DateTime.Now.ToString ();
		return temp2;
	}

	public static void Save()
	{
		FileStream file = new FileStream (databasePath, FileMode.Create);
		BinaryFormatter formatter = new BinaryFormatter ();
		formatter.Serialize (file, itens.Count);
		foreach (var item in itens) {
			formatter.Serialize (file ,item.Value);
		}
		file.Close ();
	}
}
