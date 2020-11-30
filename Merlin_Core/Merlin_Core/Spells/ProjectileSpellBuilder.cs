﻿using MerlinCore.Actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Spells
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        private Animation animation;

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
            this.animation = animation;
            return (ISpellBuilder)this.animation;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            throw new NotImplementedException();
        }
    }
}
