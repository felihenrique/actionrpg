using System;
using UnityEngine;

public class MpSystem : MonoBehaviour
{
	private int mp;
	private int maxmp;
	public int Mp {
		get { return mp; }
		set {
			MpChanged?.Invoke (value - mp);
			mp = Mathf.Clamp (value, 0, maxmp); 
		}
	}
	public int MaxMp {
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
