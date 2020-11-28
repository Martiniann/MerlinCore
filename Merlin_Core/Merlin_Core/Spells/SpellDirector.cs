using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Spells
{
    public class SpellDirector : ISpellDirector
    {

        Dictionary<string, SpellInfo> spells;
        Dictionary<string, int> effectCost;

        public ISpell Build(string spellName)
        {
            ISpellBuilder builder;
            SpellInfo spellInfo = spells[spellName];
            if (spellInfo.SpellType == SpellType.Projectile)
            {
                builder = new ProjectileSpellBuilder();
                builder.SetAnimation(new Animation("aaa", 1, 1)).AddEffect().CreateSpell();

            }
            throw new NotImplementedException();
        }
    }
}
