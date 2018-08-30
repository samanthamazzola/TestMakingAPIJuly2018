using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TestMakingAPIJuly2018
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //by default your API looks at config.Formatters (which are XML and JSON)
            //this removes XML data format to just show data in JSON format
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //need this to turn off the looping data referencing... 
            //getting customers and all info (includes orderinfo), and orders (includes customersinfo) LOOOPING
            //generate JSON from the list from table data in db
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
