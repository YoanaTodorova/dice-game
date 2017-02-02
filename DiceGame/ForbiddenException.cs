using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceGame
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message)
            : base(message)
        {

        }
    }
}