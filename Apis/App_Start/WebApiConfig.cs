using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Apis
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // always Json
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            // to convert c# capital casing to javascript camel casing
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
