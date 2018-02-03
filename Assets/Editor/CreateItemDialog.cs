using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateItemDialog : EditorWindow {
    Sprite spr = null;
    string name = "";
    bool result = false;

    [MenuItem("RPG/Itens/Create Item")]
    static void Init() {
        CreateItemDialog window = (CreateItemDialog)EditorWindow.GetWindow<CreateItemDialog>("Create Item");
        window.minSize = new Vector2(400, 150);
        window.Show();
    }

    void OnGUI() {
        spr = (Sprite)EditorGUILayout.ObjectField("Sprite: ", spr, typeof(Sprite), false);
        name = EditorGUILayout.TextField("Name: ", name);
        result = GUILayout.Button("Confirm");
        if (result)
        {
            GameObject obj = new GameObject(name);
            obj.AddComponent<Item>();
            obj.GetComponent<Item>().itemName = name;
            obj.GetComponent<Item>().icon = spr;
            obj.GetComponent<SpriteRenderer>().sprite = spr;
            PrefabUtility.CreatePrefab("Assets/Prefabs/Itens/" + name + ".prefab", obj);
        }
    }
}
