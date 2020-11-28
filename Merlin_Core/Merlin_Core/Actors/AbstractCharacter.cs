using Merlin_Core.Commands;
using Merlin_Core.Strategies;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors
{
    abstract public class AbstractCharacter : AbstractActor, ICharacter, IMovable 
    { 
     
        
        private List<Command> effects = new List<Command>();
        private double speed;
        private ISpeedStrategy speedStrategy;

        public AbstractCharacter()
        {
            speedStrategy = new NormalSpeedStrategy();
        }

        public void ChangeHealth(int delta)
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public int GetHealth()
        {
            throw new NotImplementedException();
        }

        public void AddEffect(Command effect)
        {
            throw new NotImplementedException();
        }

        public void RemoveEffect(Command effect)
        {
            throw new NotImplementedException();
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
