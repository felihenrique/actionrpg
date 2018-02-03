using UnityEngine;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System;

namespace RPG.Itens
{
    public enum GroupType
    {
        Assistance = 1,
        Crafting = 2,
        Exploration = 3,
        Treasure = 4,
        Equipment = 5
    }

    public class Item : MonoBehaviour {
        public Sprite icon;
        public GroupType group;
        public string description;
        public short price;
        // Indica se pode usar o método Use()
        public bool isUsable;
        public bool isStackable;
        public GameObject effectAplied;

        public virtual void Use(GameObject obj) 
        {
            if (effectAplied != null)
            {
                Instantiate(effectAplied, obj.transform);
            }
        }
    }   
}