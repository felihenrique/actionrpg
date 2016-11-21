using System;
using UnityEngine;

public class Equipment : Item
{
	public enum EquipmentType
	{
		Helmet, ChestPlate, Legs, Boots, Pendant, Ring, Weapon, Shield
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