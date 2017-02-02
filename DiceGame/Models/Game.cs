using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceGame.Models
{
    public class Game
    {
        private static Random Rnd = new Random();
        private static int LastId = 1;
        public int Id { get; set; }

        public User Player { get; set; }

        public int Win { get; set; }

        public int Bet { get; set; }

        public int Stake { get; set; }

        public Game(int id, int bet, int stake)
        {
            this.Id = id;
            this.Bet = bet;
            this.Stake = stake;

            if (userWins())
            {
                this.Win = this.Bet;
            }
            else
            {
                this.Win = 0;
            }
            //return this;
        }

        private bool userWins()
        {
            return true;
            var win = Rnd.Next(0, 1);
            if (win == 0)
                return false;

            return true;
        }
    }
}