using System;
using System.Collections.Generic;
using System.Linq;
using DiceGame.Models;
using DiceGame.Models.Helpers;

namespace DiceGame
{
    public class LoginRepository
    {
        static Dictionary<int, User> Logins = new Dictionary<int, User>();

        private UsersRepository _userRepository;
        public LoginRepository()
        {
            _userRepository = new UsersRepository();
            initializeData();
        }

        private void initializeData()
        {
            //Logins.Add(1, new Login(1, _userRepository.Get(1));
            throw new NotImplementedException();
        }

        public Login Create(string email, string password)
        {
            
            User user = _userRepository.GetByEmailAndPassword(email, password);
            Login login = new Login(1, user);

            return login;
        }
    }
}