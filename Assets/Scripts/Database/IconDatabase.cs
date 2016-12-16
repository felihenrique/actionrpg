using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDatabase : MonoBehaviour {
	public Sprite[] sprites;

	public Sprite get(string name)
	{
		Sprite s = System.Array.Find (sprites, (Sprite spr) => {
			return spr.name == name;
		});
		return s;
	}
}