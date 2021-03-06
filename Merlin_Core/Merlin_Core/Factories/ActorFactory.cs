﻿using MerlinCore.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Merlin_Core.Actors;

namespace MerlinCore.Factories
{
    public class ActorFactory : IFactory
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
            else if (actorType == "Switch")
            {
                actor = new Switch();
                actor.SetName(actorName);
                actor.SetPosition(x, y);

                return actor;
            }
            else if (actorType == "Door")
            {
                actor = new Door();
                actor.SetName(actorName);
                actor.SetPosition(x, y);

                return actor;
            }
            else if (actorType == "PressurePlate")
            {
                actor = new PressurePlate();
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
