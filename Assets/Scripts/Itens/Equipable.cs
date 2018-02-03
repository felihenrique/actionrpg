using System;
using UnityEngine;

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

    protected virtual void OnEquip(GameObject obj)
    {
        attr = obj.GetComponent<Attributes>();
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
