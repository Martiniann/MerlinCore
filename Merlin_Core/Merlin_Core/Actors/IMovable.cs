using Merlin_Core.Actors;
using Merlin_Core.Strategies;

namespace Merlin_Core.Commands
{
    public interface IMovable : ICharacter
    {
        void SetSpeedStrategy(ISpeedStrategy speedStrategy);
        double GetSpeed();
    }
}
