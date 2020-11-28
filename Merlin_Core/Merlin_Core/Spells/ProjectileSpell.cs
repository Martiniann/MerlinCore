using Merlin_Core.Actors;
using Merlin_Core.Commands;
using Merlin_Core.Strategies;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Spells
{
    class ProjectileSpell : AbstractActor, ISpell, IMovable
    {

        public ProjectileSpell()
        {

        }

        public ISpell AddEffect(Command effect)
        {
            throw new NotImplementedException();
        }

        public void AddEffects(IEnumerable<Command> effects)
        {
            throw new NotImplementedException();
        }

        public void Cast()
        {
            throw new NotImplementedException();
        }

        public void ChangeHealth(int delta)
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            throw new NotImplementedException();
        }

        public int GetHealth()
        {
            throw new NotImplementedException();
        }

        public double GetSpeed()
        {
            throw new NotImplementedException();
        }

        public void RemoveEffect(Command effect)
        {
            throw new NotImplementedException();
        }

        public void SetSpeedStrategy(ISpeedStrategy speedStrategy)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        void ICharacter.AddEffect(Command effect)
        {
            throw new NotImplementedException();
        }
    }
}
