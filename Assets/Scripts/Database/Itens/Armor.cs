using System;
using UnityEngine;

public class Armor : Item
{
	public enum ArmorType
	{
		Helmet, ChestPlate, Legs, Boots, Pendant, Ring
	}
	public int physical_defense;
	public int magical_defense;
	public int durability;
	public ArmorType armtype;
}