using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using DiceGame.Models.Helpers;

namespace DiceGame.Filters
{
    public class CustomAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.GetValues("Authorization").First();
            if (SkipAuthorization(actionContext))
                return;

            if (TokenManager.isTokenValid(token))
            {
                return;
            }
            else
            {
                base.OnAuthorization(actionContext);
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