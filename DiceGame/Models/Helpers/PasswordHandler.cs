using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DiceGame.Models.Helpers
{
    public static class HashGenerator
    {
        public static string GetHash(string password)
        {
            string hashstring = "";
            using (SHA512 shaM = new SHA512Managed())
            {
                var data = Encoding.UTF8.GetBytes(password);
                byte[] hash = shaM.ComputeHash(data);

                foreach (byte x in hash)
                {
                    hashstring += String.Format("{0:x2}", x);
                }
            }
            return hashstring;
        }

    }
}