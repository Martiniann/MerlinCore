using Merlin2d.Game.Actions;
using MerlinCore.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Spells
{
    public class SelfCastSpell : ISpell
    {
        public ISpell AddEffect(Command effect)
        {
            throw new NotImplementedException();
        }

        public void AddEffects(IEnumerable<Command> effects)
        {
            throw new NotImplementedException();
        }

        public void Cast()
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            throw new NotImplementedException();
        }
    }
}
