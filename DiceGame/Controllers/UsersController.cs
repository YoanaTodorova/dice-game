using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DiceGame.Filters;
using DiceGame.Models;

namespace DiceGame.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UsersRepository _repository;
        public UsersController()
        {
            this._repository = new UsersRepository();
        }

        // GET api/users
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            List<User> users = _repository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        // GET api/users/5
        [HttpGet]
        [CustomAuthorize]
        [RequireUserToBeWantedResource]
        public Task<HttpResponseMessage> Get([FromUri]int id, User authorizedUser)
        {
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, authorizedUser));
        }

        // POST api/users
        [HttpPost]
        [AllowAnonymous]
        public Task<HttpResponseMessage> Create([FromBody] User user)
        {
            _repository.Create(user);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.Created));
        }

        // PUT api/users/2
        [HttpPut]
        [CustomAuthorize]
        [RequireUserToBeWantedResource]
        public Task<HttpResponseMessage> Update([FromUri]int id, [FromBody] User user)
        {
            user.Id = id;
            _repository.Update(user);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }

        // DELETE api/users/1
        [HttpDelete]
        [CustomAuthorize]
        [RequireUserToBeWantedResource]
        public Task<HttpResponseMessage> Delete([FromUri]int id, User authorizedUser)
        {
            _repository.Delete(id);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }
    }
}
