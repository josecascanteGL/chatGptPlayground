```
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
            // Enable Cross-Origin Resource Sharing (CORS) for the Web API
            config.EnableCors();

            // Map attribute routes defined by ApiController attributes
            config.MapHttpAttributeRoutes();

            // Define a default route for Web API requests
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
```