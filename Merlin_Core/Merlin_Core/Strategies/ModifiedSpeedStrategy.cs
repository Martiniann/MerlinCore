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
        private double modifiedSpeed;

        public ModifiedSpeedStrategy(double speedMultiplier)
        {
            this.speedMultiplier = speedMultiplier;
        }

        public double GetSpeed(double speed)
        {
            modifiedSpeed = speed * speedMultiplier;
            if (modifiedSpeed > 6)
            {
                modifiedSpeed = 6;
            }
            return modifiedSpeed;
        }
    }
}
