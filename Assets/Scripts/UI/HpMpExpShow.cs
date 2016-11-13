using UnityEngine;
using System.Collections;

public class HpMpExpShow : MonoBehaviour {

	public Sprite hp_bar;
	public Sprite mp_bar;
	public Sprite exp_bar;
	public Vector2 ref_hp;
	public Vector2 ref_mp;
	public Vector2 ref_exp;
	public GameObject player;

	private HealthMpSystem hpmpSystem;
	private int old_hp;
	private int old_mp;
	private int old_exp;
	void Start () {
		hpmpSystem = player.GetComponent<HealthMpSystem> ();
		old_hp = (int)((hpmpSystem.getHP () / hpmpSystem.getMaxHP ()) * 10f);
		old_mp = (int)((hpmpSystem.getMP() / hpmpSystem.getMaxMP()) * 10f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
