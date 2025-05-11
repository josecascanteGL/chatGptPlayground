```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UnicornShopLegacy
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable Cross-Origin Resource Sharing (CORS) for the Web API.
            config.EnableCors();

            // Map attribute-based routes defined in the Web API controllers.
            config.MapHttpAttributeRoutes();

            // Define a default HTTP route for the Web API.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
```