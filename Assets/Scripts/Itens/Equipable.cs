using System;
using UnityEngine;
using RPG.Systems;

namespace RPG.Itens
{
    [Serializable]
    public struct AttributeList
    {
        public FixedAttributes type;
        public float quantity;
    }
    public class Equipable : Item
    {
        public Slot slot;

        [SerializeField]
        protected AttributeList[] attributeList;
        protected Attributes attr;

        void Start()
        {
            attr = GetComponent<Attributes>();
        }

        protected virtual void OnEquip(GameObject obj)
        {
            for (int i = 0; i < attributeList.Length; i++)
            {
                attr.AddFixed(attributeList[i].type, attributeList[i].quantity);
            }
        }

        protected virtual void OnUnequip()
        {
            for (int i = 0; i < attributeList.Length; i++)
            {
                attr.AddFixed(attributeList[i].type, -attributeList[i].quantity);
            }
        }
    }
}