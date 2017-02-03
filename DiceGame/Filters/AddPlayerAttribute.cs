using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using DiceGame.Models;

namespace DiceGame.Filters
{
    public class AddPlayerToGameAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            actionContext.ActionDescriptor.GetParameters();
            if (actionContext.ActionArguments.Keys.Contains("authorizedUser"))
            {
                User authorizedUser = (User)actionContext.ActionArguments["authorizedUser"];
                Game game = (Game)actionContext.ActionArguments["game"];
                game.PlayerId = authorizedUser.Id;

                //actionContext.ActionArguments["game"] = game;
            }
            return;
        }
    }
}