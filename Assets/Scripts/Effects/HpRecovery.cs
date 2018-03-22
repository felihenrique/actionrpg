using System;


public class HpRecovery : Effect
{
    public float quantityPerTick;

    AttributeSystem attr;

    protected override void OnInit(UnityEngine.GameObject obj)
    {
        attr = obj.GetComponent<AttributeSystem>();
    }

    protected override void OnTick()
    {
        attr.Add(VariableAttributes.HP, quantityPerTick);
        print("Recuperado: " + quantityPerTick + ". HP atual: " + attr.Get(VariableAttributes.HP));
    }
}


