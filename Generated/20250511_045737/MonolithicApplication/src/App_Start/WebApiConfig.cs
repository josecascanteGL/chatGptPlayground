/*
 * This class defines the configuration for the Web API endpoints in the UnicornShopLegacy application
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UnicornShopLegacy
{
    public static class WebApiConfig
    {
        // Method to register the configuration for the Web API
        public static void Register(HttpConfiguration config)
        {
            // Enable Cross-Origin Resource Sharing (CORS) for the Web API
            config.EnableCors();

            // Map attribute-based routes for Web API controllers
            config.MapHttpAttributeRoutes();

            // Define a default route for the Web API with a template for controllers and optional id parameter
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
*/