using MerlinCore.Actors;
using MerlinCore.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Strategies
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {

        private double speedMultiplier;

        public ModifiedSpeedStrategy( double speedMultiplier)
        {
            this.speedMultiplier = speedMultiplier;
        }

        public double GetSpeed(double speed)
        {
            return speed * speedMultiplier;
        }
    }
}
