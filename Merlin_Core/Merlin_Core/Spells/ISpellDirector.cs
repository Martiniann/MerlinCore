using System;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Spells
{
    interface ISpellDirector
    {
        ISpell Build(string spellName);
    }
}
