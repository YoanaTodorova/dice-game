using System;
using System.Collections.Generic;
using System.Linq;
using DiceGame.Models;
using DiceGame.Models.Helpers;

namespace DiceGame
{
    public class LoginRepository
    {
        static Dictionary<int, Login> Logins = new Dictionary<int, Login>();

        private UsersRepository _userRepository;
        public LoginRepository()
        {
            _userRepository = new UsersRepository();
            //initializeData();
        }

        private void initializeData()
        {
            //Logins.Add(1, new Login(1, _userRepository.Get(1));
            throw new NotImplementedException();
        }

        public Login Create(string email, string password)
        {
            
            User user = _userRepository.GetByEmailAndPassword(email, password);
            Login login = new Login(user);
            Logins[login.Id] = login;

            return login;
        }

        public Login FindByToken(string token)
        {
            List<Login> logins = GetAll()
                .Where(x => x.Token == token).ToList();

            if (logins.Count == 0)
                throw new NotFoundException("token not found");

            return logins.First();
        }

        private List<Login> GetAll()
        {
            return Logins.Values.ToList();
        }
    }
}