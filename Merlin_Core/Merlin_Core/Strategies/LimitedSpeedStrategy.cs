using MerlinCore.Actors;
using MerlinCore.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Strategies
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
