using System;
using System.Collections;
using UnityEngine;
using RPG.Itens;
using RPG.Systems;

namespace RPG.Effects
{
    public class Damage : Effect
    {
        public int damage;

        private Attributes attr;

        protected override void OnInit(GameObject obj)
        {
            attr = obj.GetComponent<Attributes>();
        }

        protected override void OnTick()
        {
            attr.Add(VariableAttributes.HP, -damage);
            print("Dano: " + damage + ". HP atual: " + attr.Get(VariableAttributes.HP));
        }
    }
}