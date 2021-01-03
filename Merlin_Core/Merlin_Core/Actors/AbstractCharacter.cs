using MerlinCore.Commands;
using MerlinCore.Strategies;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using Merlin_Core.Actors.State;

namespace MerlinCore.Actors
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter, IMovable 
    { 
     
        
        private List<Command> effects = new List<Command>();
        //private double speed;
        private int health = 100;
        private ISpeedStrategy speedStrategy;
        private int maxHp = 100;
        public bool myState = new LivingState().State;

        public AbstractCharacter()
        {
            speedStrategy = new NormalSpeedStrategy();
        }

        public void ChangeHealth(int delta)
        {
            health += delta;
            if(health > maxHp)
            {
                health = maxHp;
            }
            if(health < 0)
            {
                health = 0;
            }
        }

        public void Die()
        {
            myState = new DyingState().State;
        }

        public int GetHealth()
        {
            return health;
        }

        public void AddEffect(Command effect)
        {
            effects.Add(effect);
        }

        public void RemoveEffect(Command effect)
        {
            effects.Remove(effect);
        }

        public override void Update()
        {
            effects.ForEach(e => e.Execute());
        }

        public void SetSpeedStrategy(ISpeedStrategy speedStrategy)
        {
            this.speedStrategy = speedStrategy;
        }

        public double GetSpeed(double speed)
        {
            return speedStrategy.GetSpeed(speed);
        }
    }
}
