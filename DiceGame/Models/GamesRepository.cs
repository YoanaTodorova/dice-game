using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiceGame.Models;

namespace DiceGame
{
    public class GamesRepository
    {
        static Dictionary<int, Game> Games = new Dictionary<int, Game>();
        //{
        //    { 1, new Game { Id = 1 } },
        //    { 2, new Game { Id = 2 } }
        //};

        public Game Get(int id)
        {
            if (!Games.ContainsKey(id))
                throw new NotFoundException("No game with this id.");

            return Games[id];
        }

        public void Create(Game game)
        {
            if (Games.ContainsKey(game.Id))
                throw new Exception("Game already exists");

            Games[game.Id] = game;
        }

        public void Update(Game game)
        {
            if (!Games.ContainsKey(game.Id))
                throw new NotFoundException("No game with this id.");

            Games[game.Id] = game;
        }

        public void Delete(int id)
        {
            if (!Games.ContainsKey(id))
                throw new NotFoundException("No game with this id.");

            Games.Remove(id);
        }

        public List<Game> GetAll()
        {
            return Games.Values.ToList();
        }
    }
}