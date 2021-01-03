using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors.State
{
    public class LivingState
    {
        private bool state = true;
        public bool State
        {
            get
            {
                return state;
            }
        }
    }
}
