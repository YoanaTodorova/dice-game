using System;
using System.Collections.Generic;
using System.Linq;
using DiceGame.Models;

namespace DiceGame
{
    public class UsersRepository
    {
        Dictionary<int, User> Users = new Dictionary<int,User>()
        {
            { 1, new User { Id = 1 } },
            { 2, new User { Id = 2 } }
        };

        public User Get(int id)
        {
            if (!Users.ContainsKey(id))
                throw new NotFoundException("No user with this id.");

            return Users[id];
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
    }
}