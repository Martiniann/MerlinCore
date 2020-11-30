using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;

namespace MerlinCore.Commands
{
    public class Jump : Command
    {

        private IActor Actor;
        private int Dy;


        public Jump(IMovable movable, int dy)
        {

            if (movable is IMovable)
            {
                Dy = dy;

                Actor = (IActor)movable;
            }
            else
            {
                throw new ArgumentException("Object is not type of actor!");
            }
        }

        public void Execute()
        {
            if (Actor.GetWorld().IntersectWithWall(Actor) is false)
            {
                //Actor.SetPhysics(false);
                Actor.SetPosition(Actor.GetX(), Actor.GetY() - 3 * Dy);
                if (Actor.GetWorld().IntersectWithWall(Actor) is true)
                {
                    Actor.SetPosition(Actor.GetX(), Actor.GetY() + 3 * Dy);
                }
            }
        }
    }
}
