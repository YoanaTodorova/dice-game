using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceGame.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Token { get; set; }
        private int UserId { get; set; }

        public Login(int Id, int UserId)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.Token = "some token";
        }

        public User User()
        {
            var repo = new UsersRepository();
            User user = repo.Get(UserId);
            return user;
        }
    }
}