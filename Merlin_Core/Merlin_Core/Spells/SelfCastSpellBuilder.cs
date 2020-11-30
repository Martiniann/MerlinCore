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
        public ISpellBuilder AddEffect(string effectName)
        {
            throw new NotImplementedException();
        }

        public ISpell CreateSpell(IWizard caster)
        {
            throw new NotImplementedException();
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
