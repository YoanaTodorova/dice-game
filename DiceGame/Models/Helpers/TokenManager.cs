using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace DiceGame.Models.Helpers
{
    public static class TokenManager
    {
        static Random Rnd = new Random();

        internal static string generate()
        {
            var randomToken = Rnd.Next().ToString();
            return randomToken;
        }

        internal static bool isTokenValid(string token)
        {
            return true;
        }
    }
}