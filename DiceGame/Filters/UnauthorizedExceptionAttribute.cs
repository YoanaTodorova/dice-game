using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace DiceGame.Filters
{
    public class UnauthorizedExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is UnauthorizedAccessException)
            {
                actionExecutedContext.Response = actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    actionExecutedContext.Exception.Message);

                base.OnException(actionExecutedContext);
            }
        }
    }
}