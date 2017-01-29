using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DiceGame.Models.Helpers
{
    public static class PasswordHandler
    {
        public static string GetHash(string password)
        {
            string hashstring = password; //TODO
            using (SHA512 shaM = new SHA512Managed())
            {
                var data = Encoding.UTF8.GetBytes(password);
                byte[] hash = shaM.ComputeHash(data);
            }
            return hashstring;
        }

    }
}