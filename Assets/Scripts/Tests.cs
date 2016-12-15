using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Tests : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;

	public Sprite hpPotionSprite;
	public Sprite mpPotionSprite;
	public Sprite envenenomSprite;
	public Sprite speedSprite;

	private HealthPotion hpPotion;
	private ManaPotion mpPotion;
	private Envenenon envenenomEff;
	private Speed speedEff;
	Equipment[] equipment;
	EquipmentSystem equipSystem;
	HealthMpSystem hpmpsystem;
	AttackSystem attacksystem;
	EffectSystem effSystem;
	MovementSystem moveSystem;
	InventorySystem invSystem;

	// Use this for initialization
	void Start () {
		hpPotion = new HealthPotion ();
		hpPotion.amount = 20;
		hpPotion.consumable = true;
		hpPotion.sprite = hpPotionSprite;
		hpPotion.description = "Cura 20 de HP";
		hpPotion.group = Item.GroupType.Assistance;
		hpPotion.timeAcquired = DateTime.Now;

		mpPotion = new ManaPotion ();
		mpPotion.amount = 30;
		mpPotion.consumable = true;
		mpPotion.sprite = mpPotionSprite;
		mpPotion.description = "Recupera 20 de MP";
		mpPotion.group = Item.GroupType.Assistance;
		mpPotion.timeAcquired = DateTime.Now;

		envenenomEff = new Envenenon ();
		envenenomEff.damage = 5;
		envenenomEff.description = "Causa dano gradual no alvo";
		envenenomEff.duration = 10;
		envenenomEff.interval = 2;
		envenenomEff.sprite = envenenomSprite;
	}
	
	// Update is called once per frame
	void Update () {
	}
}

class Aaadfdfdf : ScriptableObject
{
	
}
