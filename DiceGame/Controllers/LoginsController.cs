using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DiceGame.Models;

namespace DiceGame.Controllers
{
    public class LoginsController : ApiController
    {
        private readonly LoginRepository _repository;
        public LoginsController()
        {
            _repository = new LoginRepository();
        }

        [HttpPost]
        [AllowAnonymous]
        public Task<HttpResponseMessage> Create([FromBody] User user)
        {
            var login = _repository.Create(user.Email, user.Password);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.Created, login));
        }
    }
}
