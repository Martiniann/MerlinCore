using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors.State
{
    public class DyingState
    {
        private bool state = false;
        public bool State
        {
            get
            {
                return state;
            }
        }
    }
}
