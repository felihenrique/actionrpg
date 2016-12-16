using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class ItemEditor : EditorWindow {
	
	enum TypeList {
		Item, 
		Potion 
	}
	TypeList list = TypeList.Item;

	[MenuItem("Database/Itens")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow (typeof(ItemEditor));
	}

	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (0, 0, 128, 300));
		list = (TypeList)EditorGUI.EnumPopup (new Rect (0, 0, 300, 30), "Tipo de item", list);
		GUILayout.EndArea ();
	}

	void Awake()
	{
		//ItemDatabase.Load ();
	}

	void OnDestroy()
	{
		//ItemDatabase.Save ();
		//ItemDatabase.Clear ();
	}
}
