using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;

namespace Merlin_Core.Commands
{
    public class Move : Command
    {

        private IActor Actor;
        private int Dy;
        private int Dx;
        private int Step;
        public bool hitWall = false;


        public Move(IMovable movable, int step, int dx, int dy)
        {

            if (movable is IMovable)
            {
                Step = step;
                Dy = dy;
                Dx = dx;
                Actor = (IActor)movable;
            }
            else
            {
                throw new ArgumentException("Object is not a movevable actor!");
            }
        }

        public void Execute()
        {
            if (Actor.GetWorld().IntersectWithWall(Actor) is false)
            {
                Actor.SetPosition(Actor.GetX() + Dx * Step, Actor.GetY() + Dy * Step);
                hitWall = false;
                if (Actor.GetWorld().IntersectWithWall(Actor) is true)
                {
                    hitWall = true;
                    Actor.SetPosition(Actor.GetX() - Dx * Step, Actor.GetY() - Dy * Step);
                }
            }
        }
    }
}
