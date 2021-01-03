using Merlin.Actors;
using Merlin2d.Game.Actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;
using MerlinCore.Actors;

namespace Merlin_Core.Actors
{
    public class Door : AbstractActor, IObserver
    {
        protected bool isOpened = false;
        private int x, xx;
        private int y, yy;

        private Animation animationOn;
        private Animation animationOff;

        public Door()
        {
            animationOff = new Animation("Resources/sprites/door.png", 30, 60);
            animationOn = new Animation("Resources/sprites/doorOpened.png", 30, 60);

            SetAnimation(animationOff);

        }

        public void Notify(IObservable observable)
        {
            isOpened = !isOpened;

            if (isOpened == true)
            {
                OpenDoor();
                SetAnimation(animationOn);
            }
            else
            {
                CloseDoor();
                SetAnimation(animationOff);
            }
        }

        public void SetDoor(int x, int xx, int y, int yy)
        {
            this.x = x;
            this.xx = xx;
            this.y = y;
            this.yy = yy;
        }

        public void OpenDoor()
        {
            for (int i = x; i <= xx; i++)
            {
                for (int j = y; j <= yy; j++)
                {
                    GetWorld().SetWall(i, j, false);
                }
            }
        }

        public void CloseDoor()
        {
            for (int i = x; i <= xx; i++)
            {
                for (int j = y; j <= yy; j++)
                {
                    GetWorld().SetWall(i, j, true);
                }
            }
        }   
        
        public override void Update()
        {

        }
    }
}
