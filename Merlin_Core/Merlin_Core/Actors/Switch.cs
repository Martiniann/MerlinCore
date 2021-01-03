using Merlin.Actors;
using Merlin2d.Game;
using MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors
{
    public class Switch : AbstractActor, IObservable
    {
        private bool isPressed = false;
        private Animation animationOn;
        private Animation animationOff;
        private Player player1;
        private IWorld world1;
        private int playerDistance;

        List<IObserver> observers = new List<IObserver>();
        private IObserver observer;

        public Switch()
        {
            animationOff = new Animation("Resources/sprites/switchUp.png", 33, 45);
            animationOn = new Animation("Resources/sprites/switchDown.png", 33, 45);

            SetAnimation(animationOff);
            
        }

        public void Subscribe(IObserver observer)
        {
            this.observer = observer;
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            this.observer = null;
            observers.Remove(observer);
        }
        
        public override void Update()
        {
            world1 = GetWorld();
            player1 = (Player)GetWorld().GetActors().Find(a => a is Player);
            playerDistance = GetX() - player1.GetX() + 100;

            if (Input.GetInstance().IsKeyPressed(Input.Key.C) && playerDistance >= 0)
            {
                isPressed = !isPressed;

                if (isPressed == true)
                {
                    SetAnimation(animationOn);
                }
                else
                {
                    SetAnimation(animationOff);
                }

                foreach (IObserver observer in observers)
                {
                    observer.Notify(this);
                }
            }
        }
    }
}
