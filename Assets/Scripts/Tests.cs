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
	void Start () {/*
		Potion hpPotion = new Potion ();
		hpPotion.group = Item.GroupType.Assistance;
		hpPotion.animationName = "olha a pot";
		hpPotion.itemName = "Poção de HP pequena";
		hpPotion.amountHP = 20;
		hpPotion.consumable = true;
		hpPotion.sprite = hpPotionSprite;
		hpPotion.description = "Cura 20 de HP";
		hpPotion.timeAcquired = DateTime.Now.ToString();

		Potion mpPotion = new Potion ();
		mpPotion.group = Item.GroupType.Assistance;
		mpPotion.animationName = "Curando o mp";
		mpPotion.itemName = "Poção de MP pequena";
		mpPotion.amountMP = 30;
		mpPotion.consumable = true;
		mpPotion.sprite = mpPotionSprite;
		mpPotion.description = "Recupera 20 de MP";
		mpPotion.timeAcquired = DateTime.Now.ToString();
	
		ItemDatabase.Add (hpPotion);
		ItemDatabase.Add (mpPotion);
		ItemDatabase.Save ();*/
		ItemDatabase.Load ();
		Potion hpPot = ItemDatabase.Acquire ("Poção de HP pequena") as Potion;
		print (hpPot.amountHP);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
