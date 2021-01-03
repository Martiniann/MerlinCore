using Merlin2d.Game.Actions;
using MerlinCore.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Spells
{
    public class SelfCastSpell : ISpell
    {
        private int cost;
        private List<Command> effects = new List<Command>();

        public ISpell AddEffect(Command effect)
        {
            effects.Add(effect);
            return (ISpell)effects;
        }

        public void AddEffects(IEnumerable<Command> effects)
        {
            foreach (Command effect in effects)
            {
                this.effects.Add(effect);
            }
        }

        public void Cast()
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            return cost;
        }
    }
}
