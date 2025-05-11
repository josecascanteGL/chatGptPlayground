```csharp
/*
 * This class defines the configuration of the web API.
 * It enables CORS (Cross-Origin Resource Sharing) for the API.
 * It sets up the default routes for the API controllers.
 */

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
            // Enable Cross-Origin Resource Sharing (CORS) for the API.
            config.EnableCors();

            // Map routes based on attributes present on the controller actions.
            config.MapHttpAttributeRoutes();

            // Set up a default HTTP route for the API.
            // This route template defines the structure of the URIs that the API will respond to.
            // The 'id' parameter is optional and can be passed to specific controllers.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
```