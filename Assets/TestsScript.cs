using UnityEngine;
using System.Collections;

public class TestsScript : MonoBehaviour {

	EquipmentSystem equipSystem;
	// Use this for initialization
	void Start () {
		equipSystem = GetComponent<EquipmentSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.H)) {
			Equipment sword = new Equipment ();
			sword.attack = 30;
			sword.type = Equipment.EquipmentType.Weapon;
			equipSystem.Equip (sword);
		}
	}
}
