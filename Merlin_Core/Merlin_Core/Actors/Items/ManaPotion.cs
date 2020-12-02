using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using MerlinCore.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors.Items
{
    public class ManaPotion : AbstractActor, IItem, IUsable
    {
        private int usesRemaining = 1;
        private Player player1;

        public ManaPotion()
        {
            SetAnimation(new Animation("Resources/sprites/mana_potion.png", 128, 128));
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
                player1.ChangeMana(20);
                SetAnimation(new Animation("Resources/sprites/used_potion.png", 128, 128));
                //this.RemoveFromWorld();
            }
        }
    }
}
