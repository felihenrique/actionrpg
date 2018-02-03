using System;
using System.Collections;
using UnityEngine;

public class Envenenon : Effect
{
	public int damage;

    private Attributes attr;

    protected override void OnInit(GameObject obj)
    {
        attr = obj.GetComponent<Attributes>();
    }

    protected override void OnTick()
    {
        attr.Add(VariableAttr.HP, -damage);
    }
}