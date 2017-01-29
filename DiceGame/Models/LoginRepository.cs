using System;
using System.Collections.Generic;
using System.Linq;
using DiceGame.Models;

namespace DiceGame
{
    public class LoginRepository
    {
        public Login Create(string username, string password)
        {
            User user = UsersRepository.GetByEmailAndPassword(username, password);
            Login login = new Login(1, 1);
            return login;
        }
    }
}