using Merlin_Core.Actors;
using Merlin_Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Strategies
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
