using MerlinCore.Actors;
using MerlinCore.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MerlinCore.Strategies
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
