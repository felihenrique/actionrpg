using System;
using UnityEngine;

public class MpSystem : MonoBehaviour
{
	private float mp;
	private float maxmp;
	public float Mp {
		get { return mp; }
		set {
			MpChanged?.Invoke (value - mp);
			mp = Mathf.Clamp (value, 0, maxmp); 
		}
	}
	public float MaxMp {
		get { return maxmp; }
		set {
			MaxMpChanged?.Invoke(value - maxmp);
			maxmp = value;
			mp = Mathf.Clamp (mp, 0, maxmp);
		}
	}

	public delegate void MpChangeHandler(float delta);
	public event MpChangeHandler MpChanged;
	public event MpChangeHandler MaxMpChanged;
}
