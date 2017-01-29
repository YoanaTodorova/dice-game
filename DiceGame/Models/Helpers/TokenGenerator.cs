using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceGame.Models.Helpers
{
    public static class TokenGenerator
    {
        static Random Rnd = new Random();

        internal static string generate()
        {
            var randomToken = Rnd.Next().ToString();
            return randomToken;
        }
    }
}