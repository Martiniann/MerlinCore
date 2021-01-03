using MerlinCore.Spells;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Spells
{
    public interface ISpellDataProvider
    {
        public Dictionary<string, SpellInfo> GetSpellInfo();
        public Dictionary<string, int> GetSpellEffects();
    }
}
