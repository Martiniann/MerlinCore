using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using MerlinCore.Strategies;
using System;

namespace MerlinCore.Commands
{
    public class Move : Command
    {

        private IActor Actor;
        private int Dy;
        private int Dx;
        //private int Step;
        public bool hitWall = false;
        private double speed;
        private double remainderSpeed = 0;
        private IMovable movable1;
        //private ISpeedStrategy speedStrategy = new LimitedSpeedStrategy(2);


        public Move(IMovable movable, /*int step,*/ int dx, int dy)
        {

            if (movable is IMovable)
            {
                //Step = step;
                Dy = dy;
                Dx = dx;
                Actor = (IActor)movable;
                movable1 = movable;
            }
            else
            {
                throw new ArgumentException("Object is not a movevable actor!");
            }
        }

        public void Execute()
        {
            //movable1.SetSpeedStrategy(speedStrategy);
            speed = movable1.GetSpeed(speed);

            if (Actor.GetWorld().IntersectWithWall(Actor) is false)
            {
                if (speed % 1 != 0)
                {
                    remainderSpeed += speed % 1;
                    speed = Math.Floor(speed / 1);
                }
                if (remainderSpeed % 1 == 0)
                {
                    speed += remainderSpeed;
                }
                if (speed == 0)
                {
                    speed = 1;
                }
                Actor.SetPosition((int)(Actor.GetX() + (Dx * speed)), (int)(Actor.GetY() + (Dy * speed)));
                hitWall = false;
                if (Actor.GetWorld().IntersectWithWall(Actor) is true)
                {
                    hitWall = true;
                    Actor.SetPosition((int)(Actor.GetX() - (Dx * speed)), (int)(Actor.GetY() - (Dy * speed)));
                }
            }
        }
    }
}
