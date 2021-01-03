using Merlin_Core.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Factories
{
    public class SpellEffectFactory : IFactory
    {
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            IActor actor;

            if (actorType == "fireball")
            {
                actor = new Player();
                actor.SetName(actorName);
                actor.SetPosition(x, y);

                return actor;
            }
            else if (actorType == "snowball")
            {
                actor = new Enemy();
                actor.SetName(actorName);
                actor.SetPosition(x, y);

                return actor;
            }
            else if (actorType == "arcaneball")
            {
                actor = new Switch();
                actor.SetName(actorName);
                actor.SetPosition(x, y);

                return actor;
            }
            else if (actorType == "healingtouch")
            {
                actor = new Door();
                actor.SetName(actorName);
                actor.SetPosition(x, y);

                return actor;
            }
            else
            {
                return null;
            }
        }
    }
}
