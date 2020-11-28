using Merlin_Core.Actors;
using Merlin_Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Merlin_Core.Strategies
{
    public class NormalSpeedStrategy : ISpeedStrategy
    {

        public NormalSpeedStrategy()
        {

        }

        public double GetSpeed(double speed)
        {
            return speed;
        }
    }
}
