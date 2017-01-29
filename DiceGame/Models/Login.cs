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
        public User User { get; set; }

        public Login(int Id, User User)
        {
            this.Id = Id;
            this.User = User;
            this.Token = "some token";
        }
    }
}