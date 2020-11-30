using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Spells
{
    public interface ISpell
    {
        ISpell AddEffect(Command effect);
        void AddEffects(IEnumerable<Command> effects);
        int GetCost();
        void Cast();
    }
}
