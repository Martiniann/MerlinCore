using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors
{
    public interface ICharacter
    {
        void ChangeHealth(int delta);
        int GetHealth();
        void Die();
        void AddEffect(Command effect);
        void RemoveEffect(Command effect);

    }
}
