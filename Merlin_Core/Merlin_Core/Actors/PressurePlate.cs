using Merlin2d.Game;
using Merlin2d.Game.Enums;
using MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors
{
    public class PressurePlate : AbstractActor
    {
        private Animation animationOn;
        private Animation animationOff;
        private IWorld world1;
        private Player player1;
        private int counter = 0;

        public PressurePlate()
        {
            animationOff = new Animation("Resources/sprites/plateOff.png", 50, 15);
            animationOn = new Animation("Resources/sprites/plateOn.png", 50, 15);

            SetAnimation(animationOff);
        }

        public override void Update()
        {
            world1 = GetWorld();
            player1 = (Player)GetWorld().GetActors().Find(a => a is Player);
            
            if (IntersectsWithActor(player1))
            {
                SetAnimation(animationOn);
                counter++;

                if (counter == 180)
                {
                    world1.SetEndCondition(world => MapStatus.Finished);
                }
            }
            else
            {
                SetAnimation(animationOff);
                counter = 0;  
            }
        }
    }
}
