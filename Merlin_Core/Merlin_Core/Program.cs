using MerlinCore.Factories;
using Merlin2d.Game;
using System;
using Merlin2d.Game.Actors;
using MerlinCore.Actors;
using MerlinCore.Commands;
using Merlin2d.Game.Items;
using Merlin_Core.Actors.Items;
using Merlin2d.Game.Enums;
using Merlin_Core.Actors;

namespace MerlinCore
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("MerlinCore_Game", 800, 650, true);

            container.AddWorld("Resources/maps/map03.tmx");
            container.AddWorld("Resources/maps/map02.tmx");

            Message msgWon = new Message("YOU HAVE WON", 200, 150, 50, Color.Yellow, (MessageDuration)1);
            Message msgLost = new Message("GAME OVER", 250, 150, 50, Color.Yellow, (MessageDuration)1);

            container.SetEndGameMessage(msgWon, true);
            container.SetEndGameMessage(msgLost, false);

            IWorld world = container.GetWorld(0);
            IWorld world1 = container.GetWorld(1);
            
            ActorFactory factory = new ActorFactory();
            world.SetFactory(factory);
            world1.SetFactory(factory);
     
            world.SetPhysics(new Gravity());
            world1.SetPhysics(new Gravity());

            Action<IWorld> setSubs = world => 
            { 
                Switch switch1 = (Switch)world.GetActors().Find(a => a is Switch);
                Door door1 = (Door)world.GetActors().Find(a => a is Door);
                switch1.Subscribe(door1);
                door1.SetDoor(36, 37, 31, 34);
            };

            world.AddInitAction(setSubs);

            //Action<IWorld> setCamera = world => { world.CenterOn(world.GetActors().Find(a => a.GetName() == "player")); };
            //world.AddInitAction(setCamera);

            container.Run();
        }
    }
}
