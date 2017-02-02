using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using DiceGame;
using DiceGame.Models;

namespace DiceGame.Filters
{
    public class RequireUserToBeWantedResourceAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.Keys.Contains("authorizedUser"))
            {
                User authorizedUser = (User)actionContext.ActionArguments["authorizedUser"];
                int id = (int)actionContext.ActionArguments["id"];
                if (authorizedUser.Id == id)
                    return;

                throw new ForbiddenException("Forbidden resource.");
            }
        }
    }
}