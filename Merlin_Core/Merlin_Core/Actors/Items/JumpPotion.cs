using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors.Items
{
    public class JumpPotion : AbstractActor, IItem, IUsable
    {
        private int duration = 600;
        private int usesRemaining = 1;
        private Player player1;

        public JumpPotion()
        {
            SetAnimation(new Animation("Resources/sprites/jump_potion.png", 128, 128));
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
                player1.SetJump(5);
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
