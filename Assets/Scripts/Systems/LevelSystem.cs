using System;
using UnityEngine;

public class Attr : MonoBehaviour {
    [SerializeField]
    int val;
}

public class LevelSystem : MonoBehaviour
{
    double experience = 0;
    double expNextLevel = 10;
    int level = 1;
    [SerializeField]
    AnimationCurve curve;
    [SerializeField]
    int maxLevel = 99;
    [SerializeField]
    double maxLevelReq = 9999999.0;
    [SerializeField]
    Attr[] attrs;

    public delegate void EventProt(float normalizedLevel);
    public EventProt OnLevelUp;

    public void AddExperience(double quantity) 
    {
        while (quantity > 0 && level < maxLevel)
        {
            experience += quantity;
            expNextLevel -= Math.Min(expNextLevel, quantity);
            if (expNextLevel == 0)
            {
                ++level;
                OnLevelUp(NormalizedLevel);
                quantity -= expNextLevel;
                expNextLevel = maxLevelReq * curve.Evaluate(NormalizedLevel);
            }
        }
    }

    public float NormalizedLevel 
    {
        get
        {
            return (float)level / (float)maxLevel;
        }
    }

    public int CurrentLevel 
    { 
        get 
        { 
            return level + 1;
        }
    }

    public double Experience 
    { 
        get 
        {
            return experience;
        }
    }

    public double ExperienceNextLevel 
    { 
        get 
        {
            return expNextLevel;
        }
    }
}

