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
        //[AllowAnonymous]
        [CustomAuthorize]
        public HttpResponseMessage Get()
        {
            List<User> users = _repository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        // GET api/users/5
        [HttpGet]
        //[AllowAnonymous]
        [CustomAuthorize]
        public HttpResponseMessage Get(int id)
        {
            User user = _repository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        // POST api/users
        [HttpPost]
        [AllowAnonymous]
        public Task<HttpResponseMessage> Create([FromBody] User user)
        {
            _repository.Create(user);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.Created));
        }

        [HttpPut]
        public Task<HttpResponseMessage> Update([FromBody] User user)
        {
            _repository.Update(user);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }

        // DELETE api/users/1
        [HttpDelete]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _repository.Delete(id);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK));
        }

        // PUT api/users/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
    }
}
