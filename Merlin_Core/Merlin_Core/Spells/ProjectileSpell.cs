using MerlinCore.Actors;
using MerlinCore.Commands;
using MerlinCore.Strategies;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using Merlin_Core.Actors.State;

namespace MerlinCore.Spells
{
    class ProjectileSpell : AbstractActor, ISpell, IMovable
    {

        private int cost;
        private int health;
        private int maxHp = 100;
        private List<Command> effects = new List<Command>();
        private ISpeedStrategy speedStrategy;
        public bool myState = new LivingState().State;


        public ProjectileSpell()
        {
            speedStrategy = new NormalSpeedStrategy();
        }

        public ISpell AddEffect(Command effect)
        {
            effects.Add(effect);
            return (ISpell)effects;
        }

        public void AddEffects(IEnumerable<Command> effects)
        {
            foreach (Command effect in effects)
            {
                this.effects.Add(effect);
            }
        }

        public void Cast()
        {
            throw new NotImplementedException();
        }

        public void ChangeHealth(int delta)
        {
            health += delta;
            if (health > maxHp)
            {
                health = maxHp;
            }
            if (health < 0)
            {
                health = 0;
            }
        }

        public void Die()
        {
            myState = new DyingState().State;
        }

        public int GetCost()
        {
            return cost;
        }

        public int GetHealth()
        {
            return health;
        }

        public double GetSpeed(double speed)
        {
            return speedStrategy.GetSpeed(speed);
        }

        public void RemoveEffect(Command effect)
        {
            effects.Remove(effect);
        }

        public void SetSpeedStrategy(ISpeedStrategy speedStrategy)
        {
            this.speedStrategy = speedStrategy;
        }

        public override void Update()
        {
            int beforeX = GetX();

            if (!RemovedFromWorld())
            {
                new Move(this, 4, 0).Execute();
            }
            if (beforeX == GetX())
            {
                this.RemoveFromWorld();
                speedStrategy = null;
                effects = null;
                SetAnimation(null);
            }
        }
    }
}
