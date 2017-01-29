using System;
using System.Web.Http;
using DiceGame.Filters;

namespace DiceGame
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new NotFoundExceptionAttribute());
            config.Filters.Add(new UnauthorizedExceptionAttribute());
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
