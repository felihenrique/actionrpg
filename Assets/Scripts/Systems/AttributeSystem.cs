using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public enum VariableAttributes
{
    HP,
    MP,
    Stamina
}

public enum FixedAttributes
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
[RequireComponent(typeof(LevelSystem))]
public class AttributeSystem : MonoBehaviour {
    abstract class Attribute
    {
    //TODO : Adicionar esses atributos no sistema de classe
        [SerializeField]
        protected float maxLevelValue;
        [SerializeField]
        protected float initial;
        [SerializeField]
        protected AnimationCurve curve;

        [NonSerialized]
        public float value;
        [NonSerialized]
        public float additional;
        // TODO: Adicionar a curva aqui
        public virtual void LevelUp(float normalizedLevel)
        {
            value = initial + maxLevelValue * normalizedLevel;
        }
    }

    [Serializable]
    class FixedAttr : Attribute
    {
        public FixedAttributes type;
    }

    [Serializable]
    class VariableAttr : Attribute
    {
        public VariableAttributes type;
        [NonSerialized]
        public float valueMax;
        [NonSerialized]
        public float additionalMax;

        public override void LevelUp(float normalizedLevel)
        {
            base.LevelUp(normalizedLevel);
            valueMax = value;
        }
    }
 
    [SerializeField]
    VariableAttr[] variableAttrList;
    [SerializeField]
    FixedAttr[] fixedAttrList;
    LevelSystem levelSystem; 

    void Start()
    {
        GetComponent<LevelSystem>().OnLevelUp = OnLevelUp;
    }

    void OnLevelUp(float normalizedLevel) 
    {
        foreach (var item in fixedAttrList)
        {
            item.LevelUp(normalizedLevel);
        }
        foreach (var item in variableAttrList)
        {
            item.LevelUp(normalizedLevel);
        }
    }
        
    FixedAttr FindFixed(FixedAttributes attr)
    {
        var val = fixedAttrList.FirstOrDefault(a => a.type == attr);
        if (val == null)
        {
            throw new Exception("Attribute " + Enum.GetName(typeof(FixedAttributes), attr) + " not found in " + name);
        }
        return val;
    }

    VariableAttr FindVariable(VariableAttributes attr)
    {
        var val = variableAttrList.FirstOrDefault(a => a.type == attr);
        if (val == null)
        {
            throw new Exception("Attribute " + Enum.GetName(typeof(FixedAttributes), attr) + " not found in " + name);
        }
        return val;
    }

    public float Get(VariableAttributes attr)
    {
        var val = FindVariable(attr);
        return val.value + val.additional;
    }

    public float GetMax(VariableAttributes attr)
    {
        var val = FindVariable(attr);
        return val.valueMax + val.additionalMax;
    }

    public float GetFixed(FixedAttributes attr)
    {
        var val = FindFixed(attr);
        return val.value + val.additional;
    }

    public void Add(VariableAttributes attr, float quant)
    {
        var val = FindVariable(attr);
        val.additional += quant;
    }

    public void AddMax(VariableAttributes attr, float quant)
    {
        var val = FindVariable(attr);
        val.additionalMax += quant;
    }

    public void AddFixed(FixedAttributes attr, float quant)
    {
        var val = FindFixed(attr);
        val.additional += quant;
    }
}
