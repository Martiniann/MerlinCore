using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin_Core.Actors.Items
{
    public class FullInventoryException : Exception
    {
        public FullInventoryException(string Message) : base(Message)
        {

        }
    }
}
