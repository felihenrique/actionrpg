using System;
using UnityEngine;
using System.Runtime.Serialization;

public class Potion : Item
{
	public int HpGain;
	public int MpGain;

	public override void Use (GameObject obj)
	{
		HpSystem hpSys = obj.GetComponent<HpSystem> ();
		MpSystem mpSys = obj.GetComponent<MpSystem> ();

		if (hpSys != null)
			hpSys.Hp += HpGain;
		if (mpSys != null)
			mpSys.Mp += MpGain;
	}
}
