using System;
using UnityEngine;
using System.Collections;

public class Speed : Effect
{
	public float multiplier;

    private Character character;

    protected override void OnInit(GameObject obj)
    {
        character = obj.GetComponent<Character>();
        character.Speed *= multiplier;
    }

    protected override void OnEnd()
    {
        character.Speed /= multiplier;
    }
}
