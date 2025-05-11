```c#
/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * SPDX-License-Identifier: MIT-0
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify,
 * merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UnicornShopLegacy
{
    // Class defining the configuration for the Web API
    public static class WebApiConfig
    {
        // Method to register the Web API configuration
        public static void Register(HttpConfiguration config)
        {
            // Enable Cross-Origin Resource Sharing (CORS) for the API
            config.EnableCors();

            // Map attribute-based routes defined in the controllers
            config.MapHttpAttributeRoutes();

            // Define a default route for the API
            config.Routes.MapHttpRoute(
                name: "DefaultApi", // Name of the route
                routeTemplate: "api/{controller}/{id}", // Define the URL pattern for the route
                defaults: new { id = RouteParameter.Optional }); // Default values for the route
        }
    }
}
```