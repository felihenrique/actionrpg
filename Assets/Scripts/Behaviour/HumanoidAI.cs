using UnityEngine;
using System.Collections;

public class HumanoidAI : MonoBehaviour {

	public GameObject player;
	public float attackInterval;
	public float attackStrength;

	// Componentes do enemy
	private Character character;
	private new Transform transform;
	private bool nearPlayer;
	// Componentes do player
	private HealthMpSystem plHpmpSystem;
	private Character plCharacter;

	void Start () {
		character = GetComponent<Character> ();
		transform = GetComponent<Transform> ();

		plHpmpSystem = player.GetComponent<HealthMpSystem> ();
		plCharacter = player.GetComponent<Character> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator attackRoutine() {
		while (nearPlayer) {
			yield return new WaitForEndOfFrame ();
		}
	}
}
