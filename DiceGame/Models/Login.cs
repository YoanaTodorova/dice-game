using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiceGame.Models.Helpers;

namespace DiceGame.Models
{
    public class Login
    {
        private static int LastId = 1;
        public int Id { get; set; }
        public string Token { get; set; }
        private User User { get; set; }
        public int UserId { get; set; }

        public Login(User User)
        {
            this.Id = NextId(); ;
            this.User = User;
            this.UserId = User.Id;
            this.Token = TokenManager.generate();
        }

        private int NextId()
        {
            var id = LastId;
            LastId += 1;
            return id;
        }
    }
}