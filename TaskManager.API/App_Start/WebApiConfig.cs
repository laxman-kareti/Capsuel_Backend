using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TaskManager.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
        
            config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("http://localhost,http://localhost:4200", "Content-Type", "GET,POST,PUT,DELETE,OPTIONS");
            config.EnableCors(cors);
            config.Routes.MapHttpRoute(
              name: "ActionApi1",
              routeTemplate: "api/{controller}/{action}",
              defaults: new { }
          );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            
        }
    }
}
