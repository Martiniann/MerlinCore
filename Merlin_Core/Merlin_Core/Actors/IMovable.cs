using MerlinCore.Actors;
using MerlinCore.Strategies;

namespace MerlinCore.Commands
{
    public interface IMovable
    {
        void SetSpeedStrategy(ISpeedStrategy speedStrategy);
        double GetSpeed();
    }
}
