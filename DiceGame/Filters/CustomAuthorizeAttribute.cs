using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using DiceGame.Models;
using DiceGame.Models.Helpers;

namespace DiceGame.Filters
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext))
                return;

            string token = null;
            if (actionContext.Request.Headers.Contains("Authorization"))
            {
                token = actionContext.Request.Headers.GetValues("Authorization").First();
            }
            else
            {
                throw new UnauthorizedAccessException();
            }

            if (TokenManager.isTokenValid(token))
            {
                User user = TokenManager.getUser(token);
                var identity = new GenericIdentity(user.Id.ToString());
                string[] roles = new string[0];
                var principal = new GenericPrincipal(identity, roles);
                Thread.CurrentPrincipal = principal;

                actionContext.ActionArguments["authorizedUser"] = user;
                return;
            }
            else
            {
                //base.OnAuthorization(actionContext);
                throw new UnauthorizedAccessException();
            }
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            System.Diagnostics.Contracts.Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}