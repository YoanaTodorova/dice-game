using System;
using System.Collections.Generic;
using System.Linq;
using DiceGame.Models;

namespace DiceGame
{
    public class LoginRepository
    {
        private UsersRepository _userRepository;
        public LoginRepository()
        {
            _userRepository = new UsersRepository();
        }

        public Login Create(string email, string password)
        {
            
            User user = _userRepository.GetByEmailAndPassword(email, password);
            Login login = new Login(1, user);
            return login;
        }
    }
}