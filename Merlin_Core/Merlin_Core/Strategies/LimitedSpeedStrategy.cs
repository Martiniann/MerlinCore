using Merlin_Core.Actors;
using Merlin_Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Strategies
{
    public class LimitedSpeedStrategy : ISpeedStrategy
    {

        private double max;

        public LimitedSpeedStrategy(double max)
        {
            this.max = max;
        }

        public double GetSpeed(double speed)
        {
            return speed< max ? speed : max;
        }
    }
}
