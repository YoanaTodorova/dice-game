using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceGame.Models
{
    public class Game
    {
        private static Random Rnd = new Random();
        private static UsersRepository _userRepository = new UsersRepository();

        private static int LastId = 1;
        public int Id { get; set; }

        //public User Player { get; set; }
        public int PlayerId { get; set; }

        public int Win { get; set; }

        public int Bet { get; set; }

        public int Stake { get; set; }

        //public Game()
        //    : base()
        //{
        //    this.Id = NextId();
        //    //this.Player = _userRepository.Get(this.PlayerId);

        //    if (userWins())
        //        this.Win = this.Bet;
        //}

        public Game(int bet, int stake)
        {
            this.Id = NextId();
            //this.PlayerId = playerId;
            //this.Player = _userRepository.Get(playerId);

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
        }

        private bool userWins()
        {
            var win = Rnd.Next(0, 2);
            if (win == 0)
                return false;

            return true;
        }

        private int NextId()
        {
            var id = LastId;
            LastId += 1;
            return id;
        }
    }
}