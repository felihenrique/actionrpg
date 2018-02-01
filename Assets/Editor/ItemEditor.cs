using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class ItemEditor : EditorWindow {
    Rigidbody2D plrigid;
	[MenuItem("Database/Itens")]
	public static void ShowWindow()
	{
        Debug.Log(sizeof(GroupType));
		//EditorWindow.GetWindow (typeof(ItemEditor));
	}

	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (0, 0, 128, 300));
        plrigid = (Rigidbody2D)EditorGUILayout.ObjectField(plrigid, typeof(Rigidbody2D), true);
        bool clicked = GUILayout.Button("Click");
        if (clicked)
        {
            
        }
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
