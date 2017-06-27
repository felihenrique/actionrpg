using UnityEngine;
using System.Collections;

public class HpSystem : MonoBehaviour {

	private float hp;
	private float maxhp;

	public delegate void HpChangeHandler (float delta);
	public delegate void BlockDamageHandler ();
	public delegate void DeathHandler ();
	public event HpChangeHandler HpChanged;
	public event HpChangeHandler MaxHpChanged;
	public event DeathHandler Died;
	// TODO: Implementar DamageSystem e colocar o evento blocked_damage
	public float Hp {
		get { return hp; }
		set {
			HpChanged?.Invoke (value - hp);
			hp = Mathf.Clamp (value, 0, maxhp);
			if (hp == 0)
				Died?.Invoke ();
		}
	}

	public float MaxHp {
		get { return maxhp; }
		set { 
			MaxHpChanged?.Invoke (value - maxhp);
			maxhp = value;
			hp = Mathf.Clamp (hp, 0, maxhp);
		}
	}
}

