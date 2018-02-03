using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG.Systems
{
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

    [Serializable]
    public struct FixedAttrData
    {
        public FixedAttributes type;
        public float initial;
    }

    [Serializable]
    public struct AttrData
    {
        public VariableAttributes type;
        public float initialMax;
    }

    public class Attributes : MonoBehaviour {
        [SerializeField]
        private AttrData[] attributesList;
        [SerializeField]
        private FixedAttrData[] fixedAttributesList;

        private Dictionary<FixedAttributes, float> fixedAttributes = new Dictionary<FixedAttributes, float>();
        private Dictionary<VariableAttributes, float> variableAttributes = new Dictionary<VariableAttributes, float>();
        private Dictionary<VariableAttributes, float> variableAttributesMax = new Dictionary<VariableAttributes, float>();

        void Awake() 
        {
            for (int i = 0; i < attributesList.Length; i++)
            {
                variableAttributes[attributesList[i].type] = attributesList[i].initialMax;
                variableAttributesMax[attributesList[i].type] = attributesList[i].initialMax;
            }
            for (int i = 0; i < fixedAttributesList.Length; i++)
            {
                fixedAttributes[fixedAttributesList[i].type] = fixedAttributesList[i].initial;
            }
        }

        public float Get(VariableAttributes attr)
        {
            if (variableAttributes.ContainsKey(attr))
            {
                return variableAttributes[attr];
            }
            else
            {
                print("O character " + gameObject.name + " não contém o atributo " + Enum.GetName(typeof(VariableAttributes), attr));
                return 0;
            }
        }

        public float GetMax(VariableAttributes name)
        {
            if (variableAttributesMax.ContainsKey(name))
            {
                return variableAttributes[name];
            }
            else
            {
                print("O character " + gameObject.name + " não contém o atributo " + Enum.GetName(typeof(VariableAttributes), name));
                return 0;
            }
        }

        public float GetFixed(FixedAttributes name)
        {
            if (fixedAttributes.ContainsKey(name))
            {
                return fixedAttributes[name];
            }
            else
            {
                print("O character " + gameObject.name + " não contém o atributo " + Enum.GetName(typeof(VariableAttributes), name));
                return 0;
            }
        }

        public void Add(VariableAttributes name, float quant)
        {
            if (variableAttributes.ContainsKey(name) && variableAttributesMax.ContainsKey(name))
            {
                variableAttributes[name] += quant;
                variableAttributes[name] = Mathf.Clamp(variableAttributes[name], 0, variableAttributesMax[name]); 
            }
            else
            {
                print("O character " + gameObject.name + " não contém o atributo " + Enum.GetName(typeof(VariableAttributes), name));
            }
        }

        public void AddMax(VariableAttributes name, float quant)
        {
            if (variableAttributes.ContainsKey(name) && variableAttributesMax.ContainsKey(name))
            {
                variableAttributesMax[name] += quant;
            }
            else
            {
                print("O character " + gameObject.name + " não contém o atributo " + Enum.GetName(typeof(VariableAttributes), name));
            }
        }

        public void AddFixed(FixedAttributes name, float quant)
        {
            if (fixedAttributes.ContainsKey(name))
            {
                fixedAttributes[name] += quant;
            }
            else
            {
                print("O character " + gameObject.name + " não contém o atributo " + Enum.GetName(typeof(VariableAttributes), name));
            }
        }
    }
}