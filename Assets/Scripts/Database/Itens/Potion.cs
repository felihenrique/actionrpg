using System;
using UnityEngine;
using System.Runtime.Serialization;

public class Potion : Item
{
	public int HpGain;
	public int MpGain;

	public override void Use (GameObject obj)
	{
        Attributes attr = obj.GetComponent<Attributes>();

        if (attr != null)
        {
            attr.Add(VariableAttr.HP, HpGain);
            attr.Add(VariableAttr.MP, MpGain);
        }
	}
}
