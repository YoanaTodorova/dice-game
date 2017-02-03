using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DiceGame.Models
{
    public class User
    {
        private static int LastId = 1;
        
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }

        public Balance CurrentBalance { get; set; }

        public User(string email, string fullName, string password)
        {
            this.Id = NextId();
            this.CurrentBalance = new Balance(this.Id);

            this.Email = email;
            this.FullName = fullName;
            this.Password = password;
        }

        private int NextId()
        {
            var id = LastId;
            LastId += 1;
            return id;
        }
    }
}