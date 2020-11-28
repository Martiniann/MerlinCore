using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Spells
{
    interface ISpellDirector
    {
        ISpell Build(string spellName);
    }
}
