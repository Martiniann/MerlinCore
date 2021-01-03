using Merlin_Core.Spells;
using Merlin2d.Game;
using MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Spells
{
    public class SpellDirector : ISpellDirector
    {

        Dictionary<string, SpellInfo> spells;
        Dictionary<string, int> effectCost;


        public SpellDirector(ISpellDataProvider provider)
        {
            spells = provider.GetSpellInfo();
        }

        public ISpell Build(string spellName)
        {
            ISpellBuilder builder;
            SpellInfo spellInfo = spells[spellName];
            if (spellInfo.SpellType == SpellType.Projectile)
            {
                builder = new ProjectileSpellBuilder();
                if (spellInfo.Name == "fireball")
                {
                    builder.SetAnimation(new Animation("Resources/sprites/fireball.png", 64, 32));
                }
                else if (spellInfo.Name == "snowball")
                {
                    builder.SetAnimation(new Animation("Resources/sprites/snowball.png", 64, 32));
                }
            }
            else
            {
                builder = new SelfCastSpellBuilder();
            }

            return builder.AddEffect("DoT").AddEffect("slow").CreateSpell(null);
        }
    }
}
