using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace DiceGame.Filters
{
    public class ForbiddenExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ForbiddenException)
            {
                actionExecutedContext.Response = actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.Forbidden,
                    actionExecutedContext.Exception.Message);

                base.OnException(actionExecutedContext);
            }
        }
    }
}