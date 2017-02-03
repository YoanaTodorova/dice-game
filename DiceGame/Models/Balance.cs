using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceGame.Models
{
    public class Balance
    {
        private static int LastId = 1;

        public int Id { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }

        public Balance(int userId)
        {
            this.Id = NextId();
            this.UserId = userId;
        }

        private int NextId()
        {
            var id = LastId;
            LastId += 1;
            return id;
        }
    }
}