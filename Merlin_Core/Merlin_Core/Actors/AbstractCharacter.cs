using MerlinCore.Commands;
using MerlinCore.Strategies;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Actors
{
    abstract public class AbstractCharacter : AbstractActor, ICharacter, IMovable 
    { 
     
        
        private List<Command> effects = new List<Command>();
        private double speed;
        private int health;
        private ISpeedStrategy speedStrategy;

        public AbstractCharacter()
        {
            speedStrategy = new NormalSpeedStrategy();
        }

        public void ChangeHealth(int delta)
        {
            health += delta;
        }

        public void Die()
        {
            throw new NotImplementedException();
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

        public double GetSpeed()
        {
            return speedStrategy.GetSpeed(speed);
        }
    }
}
