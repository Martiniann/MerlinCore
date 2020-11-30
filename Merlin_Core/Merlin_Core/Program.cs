using MerlinCore.Factories;
using Merlin2d.Game;
using System;
using Merlin2d.Game.Actors;
using MerlinCore.Actors;

namespace MerlinCore
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("MerlinCore_Game", 805, 595);
            container.SetMap("Resources/maps/map03.tmx");
            IWorld world = container.GetWorld();

            world.SetFactory(new ActorFactory());
            ActorFactory factory = new ActorFactory();
            world.AddActor(factory.Create("Player", "Merlin", 384, 223));
            //container.AddActor(factory.Create("Player", "Merlin", 384, 223));


            Action<IWorld> setCamera = world => { world.CenterOn(world.GetActors().Find(a => a.GetName() == "player")); };
            world.AddInitAction(setCamera);

            container.Run();
        }
    }
}
