using Merlin_Core.Actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Spells
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        public ISpellBuilder AddEffect(string effectName)
        {
            throw new NotImplementedException();
        }

        public ISpell CreateSpell(IWizard caster)
        {
            ISpell spell = new ProjectileSpell();
            return spell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            throw new NotImplementedException();
        }
    }
}
