using System;
using System.Collections.Generic;
using System.Linq;
using DiceGame.Models;
using DiceGame.Models.Helpers;

namespace DiceGame
{
    public class UsersRepository
    {
        static Dictionary<int, User> Users = new Dictionary<int,User>()
        {
            { 1, new User { Id = 1 } },
            { 2, new User { Id = 2 } }
        };

        public static void SetUsersRepository(List<User> usrlist)
        {
            Users.Clear();
            foreach (User item in usrlist)
            {
                if (!Users.ContainsKey(item.Id))
                {
                    Users.Add(item.Id, item);
                }
            }
        }
        public User Get(int id)
        {
            if (!Users.ContainsKey(id))
                throw new NotFoundException("No user with this id.");

            return Users[id];
        }

        public static User GetByEmailAndPassword(string username, string password)
        {
            string pwhash = HashGenerator.GetHash(password);
            User user = GetAll().Where(x => x.Email.ToLower() == username.ToLower() && x.Password == pwhash).First();
            if (user == null)
                throw new NotFoundException("No user with this id.");

            return user;
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

        public static List<User> GetAll()
        {
            return Users.Values.ToList();
        }
    }
}