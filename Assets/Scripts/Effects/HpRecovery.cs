using System;
using RPG.Systems;

namespace RPG.Effects
{
    public class HpRecovery : Effect
    {
        public float quantityPerTick;

        Attributes attr;

        protected override void OnInit(UnityEngine.GameObject obj)
        {
            attr = obj.GetComponent<Attributes>();
        }

        protected override void OnTick()
        {
            attr.Add(VariableAttributes.HP, quantityPerTick);
            print("Recuperado: " + quantityPerTick + ". HP atual: " + attr.Get(VariableAttributes.HP));
        }
    }
}

