using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors.Items
{
    public class HealingPotion : AbstractActor, IItem, IUsable
    {
        private int usesRemaining = 1;
        private Player player1;

        public HealingPotion()
        {
            SetAnimation(new Animation("Resources/sprites/health_potion.png", 128, 128));
        }
        public int UsesRemaining()
        {
            return usesRemaining; 
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }

        public void Use(IActor actor)
        {
            player1 = (Player)actor;
            if (usesRemaining-- > 0)
            {
                player1.ChangeHealth(20);
                SetAnimation(new Animation("Resources/sprites/used_potion.png", 128, 128));
                //this.RemoveFromWorld();
            }
        }
    }
}
