using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Tests : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;

	public Sprite hpPotionSprite;
	public Sprite mpPotionSprite;
	public Sprite envenenomSprite;
	public Sprite speedSprite;

	Potion hpPotion;
	Potion mpPotion;
	Envenenon envenenomEff;
	Speed speedEff;
	Equipment[] equipment;
	EquipmentSystem equipSystem;
	HealthMpSystem hpmpsystem;
	AttackSystem attacksystem;
	EffectSystem effSystem;
	MovementSystem moveSystem;
	InventorySystem invSystem;

	// Use this for initialization
	void Start () {
		hpPotion = new Potion ();
		hpPotion.group = Item.GroupType.Assistance;
		hpPotion.animationName = "olha a pot";
		hpPotion.itemName = "Poção de HP pequena";
		hpPotion.amountHP = 20;
		hpPotion.consumable = true;
		hpPotion.sprite = hpPotionSprite;
		hpPotion.description = "Cura 20 de HP";
		hpPotion.timeAcquired = DateTime.Now.ToString();

		mpPotion = new Potion ();
		mpPotion.group = Item.GroupType.Assistance;
		mpPotion.animationName = "Curando o mp";
		hpPotion.itemName = "Poção de MP pequena";
		mpPotion.amountMP = 30;
		mpPotion.consumable = true;
		mpPotion.sprite = mpPotionSprite;
		mpPotion.description = "Recupera 20 de MP";
		mpPotion.timeAcquired = DateTime.Now.ToString();
		
		List<Item> itens1 = new List<Item> ();
		itens1.Add (hpPotion);
		itens1.Add (mpPotion);
		FileStream file1 = new FileStream ("Assets/Scripts/Database/itens.data", FileMode.Create);
		BinaryFormatter formater = new BinaryFormatter ();
		formater.Serialize (file1, itens1);
		file1.Close ();
		
		List<Item> itens;
		FileStream file = new FileStream ("Assets/Scripts/Database/itens.data", FileMode.Open);
		BinaryFormatter formatter = new BinaryFormatter ();
		itens = formatter.Deserialize (file) as List<Item>;

		foreach (var item in itens) {
			print (item.itemName);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
