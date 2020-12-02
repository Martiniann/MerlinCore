using MerlinCore.Factories;
using Merlin2d.Game;
using System;
using Merlin2d.Game.Actors;
using MerlinCore.Actors;
using MerlinCore.Commands;
using Merlin2d.Game.Items;
using Merlin_Core.Actors.Items;

namespace MerlinCore
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("MerlinCore_Game", 800, 650);
            container.SetMap("Resources/maps/map08.tmx");
            IWorld world = container.GetWorld();

            world.SetFactory(new ActorFactory());
            ActorFactory factory = new ActorFactory();
            world.AddActor(factory.Create("Player", "player", 384, 223));

            world.SetPhysics(new Gravity());

            //IInventory backpack = new Backpack(6);
            //backpack.AddItem(new HealingPotion());
            //backpack.AddItem(new HealingPotion());
            //backpack.AddItem(new HealingPotion());
            //backpack.AddItem(new ManaPotion());
            //backpack.AddItem(new ManaPotion());
            //backpack.AddItem(new ManaPotion());


            //backpack.ShiftLeft();
            //backpack.ShiftRight();
            //backpack.ShiftRight();
            //backpack.RemoveItem(5);
            //backpack.RemoveItem(new ManaPotion());
            //backpack.GetItem();
            //world.ShowInventory(backpack);
            
            Message msg = new Message("INVENTORY", 250, 618, 20, Color.Yellow, (MessageDuration)1); //optional arguments: fontSize, color, duration
            
            world.AddMessage(msg);
            //world.RemoveMessage(msg);

            //Action<IWorld> setCamera = world => { world.CenterOn(world.GetActors().Find(a => a.GetName() == "player")); };
            //world.AddInitAction(setCamera);

            container.Run();
        }
    }
}
