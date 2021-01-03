using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using MerlinCore.Actors;
using MerlinCore.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors.Items
{
    public class SpeedPotion : AbstractActor, IItem, IUsable
    {
        private int duration = 600;
        private int usesRemaining = 1;
        private Player player1;
        private ISpeedStrategy speedStrategy = new ModifiedSpeedStrategy(3);

        public SpeedPotion()
        {
            SetAnimation(new Animation("Resources/sprites/speed_potion.png", 128, 128));
        }

        public int UsesRemaining()
        {
            return usesRemaining;
        }

        public int GetDuration()
        {
            return duration;
        }

        public void Use(IActor actor)
        {
            player1 = (Player)actor;
            if (usesRemaining-- > 0)
            {
                player1.SetSpeedStrategy(speedStrategy);
                SetAnimation(new Animation("Resources/sprites/used_potion.png", 128, 128));
                //this.RemoveFromWorld();
            }
        }
        
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
