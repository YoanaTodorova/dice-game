using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DiceGame.Models;

namespace DiceGame.Controllers
{
    [Authorize]
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
            var users = UsersRepository.GetAll();
            Models.Helpers.DataBaseHandler.SetUsers(UsersRepository.GetAll());
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        // GET api/users/5
        //[NotFoundExceptionAttribute]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Get(int id)
        {
            var user = _repository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        // POST api/users
        [HttpPost]
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

        // DELETE api/users/5
        //public void Delete(int id)
        //{
        //}
    }
}
