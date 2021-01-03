using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Spells
{
    public class SpellInfo
    {
        public string Name { get; set; }
        public SpellType SpellType { get; set; }
        public IEnumerable<string> EffectNames { get; set; }
        public string AnimationPath { get; set; }
        public int AnimationWidth { get; set; }
        public int AnimationHeight { get; set; }

        public static implicit operator SpellInfo(string line)
        {
            string[] values = line.Split(';');

            SpellInfo info = new SpellInfo { Name = values[0], AnimationPath = values[2], AnimationWidth = Convert.ToInt32(values[3]), AnimationHeight = Convert.ToInt32(values[4]) /*,EffectNames = values[5]*/ };

            info.EffectNames = (IEnumerable<string>)(IEnumerable)values[5];

            if (values[1].ToLower().Equals("projectile"))
            {
                info.SpellType = SpellType.Projectile;
            }
            else if (values[1].ToLower().Equals("selfcast"))
            {
                info.SpellType = SpellType.SelfCast;
            }

            return info;
        }
    }
}
