using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DiceGame.Filters;
using DiceGame.Models;

namespace DiceGame.Controllers
{  
    [CustomAuthorize]
    public class GamesController : ApiController
    {
        private readonly GamesRepository _repository;
        private readonly UsersRepository _userRepository;
        public GamesController()
        {
            this._repository = new GamesRepository();
            this._userRepository = new UsersRepository();
        }

        // GET api/games
        [HttpGet]
        public Task<HttpResponseMessage> GetAll()
        {
            List<Game> games = _repository.GetAll();
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, games));
        }

        // GET api/users/5
        [HttpGet]
        //[AllowAnonymous]
        public HttpResponseMessage Get(int id)
        {
            Game game = _repository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, game);
        }

        // POST api/games
        [HttpPost]
        public Task<HttpResponseMessage> Create([FromBody] Game game)
        {
            var identityId = Int32.Parse(User.Identity.Name);
            User identityUser = _userRepository.Get(identityId);

            _repository.Create(game, identityUser);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.Created));
        }

        [HttpPut]
        public Task<HttpResponseMessage> Update([FromBody] Game game)
        {
            _repository.Update(game);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }

        // DELETE api/users/1
        [HttpDelete]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _repository.Delete(id);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }
    }
}
