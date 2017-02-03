using System;
using System.Collections.Generic;
using System.Linq;
using DiceGame.Models;

namespace DiceGame
{
    public class UsersRepository
    {
        static Dictionary<int, User> Users = new Dictionary<int,User>()
        {
            { 1, new User("email1", "full name 1", "password1") },
            { 2, new User("email2", "full name 2", "password2") }
        };

        public User Get(int id)
        {
            if (!Users.ContainsKey(id))
                throw new NotFoundException("No user with this id.");

            return Users[id];
        }

        //TODO: Find user by email and then compare to password; if not - throw Unauthorized
        public User GetByEmailAndPassword(string email, string password)
        {
            //string pwhash = PasswordHandler.GetHash(password);
            string pwhash = password;
            List<User> users = GetAll()
                .Where(x => x.Email.ToLower() == email.ToLower() && x.Password == pwhash).ToList();
            if (users.Count == 0)
                throw new UnauthorizedAccessException("Wrong username or password.");

            return users.First();
        }

        public void Create(User user)
        {
            if (Users.ContainsKey(user.Id))
                throw new Exception("User already exists");

            Users[user.Id] = user;
        }

        public void Update(User user)
        {
            if (!Users.ContainsKey(user.Id))
                throw new NotFoundException("No user with this id.");

            Users[user.Id] = user;
        }

        public void Delete(int id)
        {
            if (!Users.ContainsKey(id))
                throw new NotFoundException("No user with this id.");

            Users.Remove(id);
        }

        public List<User> GetAll()
        {
            return Users.Values.ToList();
        }

        public Balance GetUserAmount(int id)
        {
            if (!Users.ContainsKey(id))
                throw new KeyNotFoundException("No user with this id.");

            return Get(id).CurrentBalance;
        }
    }
}