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
        private static UsersRepository _userRepository = new UsersRepository();
        private static LoginRepository _loginRepository = new LoginRepository();

        internal static string generate()
        {
            var randomToken = Rnd.Next().ToString();
            return randomToken;
        }

        internal static bool isTokenValid(string token)
        {
            try
            {
                Login login = _loginRepository.FindByToken(token);
            }
            catch (NotFoundException)
            {
                return false;
            }
            return true;
        }

        internal static User getUser(string token)
        {
            Login login = _loginRepository.FindByToken(token);
            User user = _userRepository.Get(login.UserId);
            return user;
        }

        internal static System.Security.Principal.IPrincipal getUser()
        {
            throw new NotImplementedException();
        }
    }
}