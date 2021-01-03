using Merlin2d.Game;
using MerlinCore.Actors;
using MerlinCore.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Spells
{
    public class SelfCastSpellBuilder : ISpellBuilder
    {
        private Animation animation;
        private int cost;

        private List<string> effects = new List<string>();

        public ISpellBuilder AddEffect(string effectName)
        {
            effects.Add(effectName);
            return (ISpellBuilder)effects;
        }

        public ISpell CreateSpell(IWizard caster)
        {
            ISpell spell = new ProjectileSpell();
            return spell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            this.animation = animation;
            return (ISpellBuilder)this.animation;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            //this.cost = cost;
            //return (ISpellBuilder)this.cost;
            throw new NotImplementedException();
        }
    }
}
