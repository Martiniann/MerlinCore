using Merlin_Core.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Merlin_Core.Factories
{
    class ActorFactory : IFactory
    {
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            if (actorType == "Player")
            {
                return new Player();
            }
            else if (actorType == "Enemy")
            {
                return new Enemy();
            }

            return null;
        }
    }
}
