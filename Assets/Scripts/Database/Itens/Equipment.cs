﻿using System;
using UnityEngine;

public class Equipment : Item
{
	public enum EquipmentType
	{
		Helmet = 1,
		ChestPlate = 2,
		Legs = 3,
		Boots = 4,
		Pendant = 5,
		Ring = 6,
		Weapon = 7,
		Shield = 8
	}
	public float physicalResistance;
	public float magicalResistance;
	public float durability;
	public float attack;
	public float attackGainPercent;
	public float magicalAttack;
	public float magicalAttackGainPercent;
	public float blockChance;
	public float hpGain;
	public float mpGain;
	public float hpGainPercent;
	public float mpGainPercent;
	public EquipmentType type;
}