using System;

namespace DiceGame
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        { }
    }
}