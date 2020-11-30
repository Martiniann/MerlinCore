using System;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Strategies
{
    public interface ISpeedStrategy
    {
        double GetSpeed(double speed);
    }
}
