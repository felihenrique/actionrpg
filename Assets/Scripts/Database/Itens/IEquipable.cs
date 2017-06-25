using System;
using UnityEngine;

public interface IEquipable
{
	void Equip (GameObject obj);
	void UnEquip(GameObject obj);
	Slot Slot { get; set; }
}