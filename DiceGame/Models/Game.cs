using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceGame.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }

        public int WinnerId { get; set; }
        public int WonAmount { get; set; }

        public int Bet1 { get; set; }
        public int Bet2 { get; set; }

        public int Stake1 { get; set; }
        public int Stake2 { get; set; }
    }
}