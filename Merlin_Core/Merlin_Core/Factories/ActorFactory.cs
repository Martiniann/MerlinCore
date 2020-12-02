using MerlinCore.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace MerlinCore.Factories
{
    class ActorFactory : IFactory
    {


        public IActor Create(string actorType, string actorName, int x, int y)
        {
            IActor actor;

            if (actorType == "Player")
            {
                actor = new Player();
                actor.SetName(actorName);
                actor.SetPosition(x, y);

                return actor;
            }
            else if (actorType == "Enemy")
            {
                actor = new Enemy();
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
