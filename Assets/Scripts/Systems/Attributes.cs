using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum VariableAttr
{
    HP,
    MP
}

public enum FixedAttr
{
    PhysicalResistance,
    MagicalResistance,
    MaxMpGain,
    MaxHpGain,
    Attack,
    AttackMultiplier,
    MagicAttack
}
// TODO: Colocar o dicionario no inspector, atraves do array

public class Attributes : MonoBehaviour {
    private Dictionary<FixedAttr, float> fixedAttr;
    private Dictionary<VariableAttr, float> variableAttr;
    private Dictionary<VariableAttr, float> variableAttrMax;
	// Use this for initialization
	void Start () {
        fixedAttr = new Dictionary<FixedAttr, float>();
        variableAttr = new Dictionary<VariableAttr, float>();
        variableAttrMax = new Dictionary<VariableAttr, float>();
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
