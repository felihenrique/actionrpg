using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum VariableAttr
{
    HP,
    MP,
    Stamina
}

public enum FixedAttr
{
    // Resistance
    PhysicalResistance,
    MagicalResistance,
    PhysicalResistanceMultiplier,
    MagicalResistanceMultiplier,
    // Attack and Magic attack
    Attack,
    AttackMultiplier,
    MagicAttack,
    MagicAttackMultiplier,
    // Hp and Mp
    HpMultiplier,
    MpMultiplier,
    // Defense
    BlockChance,
    // Basic Attributes
    Strength,
    Agility,
    Hit,
    Intelligence,
    Luck,
    CriticalChance,
    // Recovery
    MpRec,
    HpRec,
    StaminaRec,

}

[Serializable]
public struct FixedAttrData
{
    public FixedAttr type;
    public float initial;
}
[Serializable]
public struct AttrData
{
    public VariableAttr type;
    public float initialMax;
}
// TODO: Colocar o dicionario no inspector, atraves do array

public class Attributes : MonoBehaviour {
    [SerializeField]
    private AttrData[] attributes;
    [SerializeField]
    private FixedAttrData[] fixedAttributes;

    private Dictionary<FixedAttr, float> fixedAttr = new Dictionary<FixedAttr, float>();
    private Dictionary<VariableAttr, float> variableAttr = new Dictionary<VariableAttr, float>();
    private Dictionary<VariableAttr, float> variableAttrMax = new Dictionary<VariableAttr, float>();

    void Awake() {
        for (int i = 0; i < attributes.Length; i++)
        {
            variableAttr[attributes[i].type] = attributes[i].initialMax;
            variableAttrMax[attributes[i].type] = attributes[i].initialMax;
        }
        for (int i = 0; i < fixedAttributes.Length; i++)
        {
            fixedAttr[fixedAttributes[i].type] = fixedAttributes[i].initial;
        }
    }

    public void Add(VariableAttr name, float quant)
    {
        if (variableAttr.ContainsKey(name) && variableAttrMax.ContainsKey(name))
        {
            variableAttr[name] += quant;
            variableAttr[name] = Mathf.Clamp(variableAttr[name], 0, variableAttrMax[name]); 
        }
        else
        {
            print("O atributo " + name + " não existe");
        }
    }

    public void AddMax(VariableAttr name, float quant)
    {
        if (variableAttr.ContainsKey(name) && variableAttrMax.ContainsKey(name))
        {
            variableAttrMax[name] += quant;
        }
        else
        {
            print("O atributo " + name + " não existe");
        }
    }

    public void AddFixed(FixedAttr name, float quant)
    {
        if (fixedAttr.ContainsKey(name))
        {
            fixedAttr[name] += quant;
        }
        else
        {
            print("O atributo " + name + " não existe");
        }
    }
}
