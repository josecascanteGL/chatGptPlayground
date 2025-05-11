```csharp
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
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using UnicornShopLegacy.Interfaces;

namespace UnicornShopLegacy
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Call the method to populate the database if it's empty
            Populate_DB_If_None();
            // Register Web API configuration
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private static void Populate_DB_If_None()
        {
            // Create an instance of the Entity Framework context
            var context = new UnishopEntities();

            // Check if the database already exists
            if (!context.Database.Exists())
            {
                // If the database does not exist, create the database
                context.Database.Create();

                // Connect directly to the database to add a computed column to the 'inventory' table using a SQL statement
                SqlConnection sqlCon = new SqlConnection(@"Data Source=db.unishop.local,1433\unishop; initial catalog=Unishop; User ID=admin; Password=dMdLgX6sZoXmOU2rnWTS;");
                SqlDataAdapter sqlda = new SqlDataAdapter("ALTER TABLE inventory ADD year_model AS (datepart(year,date_create)); ", sqlCon);
                // Execute the SQL statement to add the computed column
                sqlda.Fill(new DataTable());

                // Read the lines from the unicorns.csv file
                string[] readText = File.ReadAllLines(HttpContext.Current.Server.MapPath(".") + @"\unicorns.csv");
                // Create a list to store the new unicorns
                IList<inventory> newunicorns = new List<inventory>();
                // Iterate through each line in the CSV file
                foreach (var line in readText)
                {
                    // Split the line by comma to get individual fields
                    string[] fields = line.Split(',');
                    // Create a new inventory object for the unicorn
                    var unicorn = new inventory();
                    // Populate the unicorn object's properties from the CSV fields
                    unicorn.unicorn_id = Guid.Parse(fields[0]);
                    unicorn.name = fields[1];
                    unicorn.description = fields[2];
                    unicorn.price = Convert.ToDecimal(fields[3]);
                    unicorn.image = fields[4];
                    unicorn.date_create = Convert.ToDateTime(fields[5]);
                    // Add the new unicorn to the list
                    newunicorns.Add(unicorn);
                }

                // Add all new unicorns to the context
                context.inventories.AddRange(newunicorns);
                // Save the changes to the database
                context.SaveChanges();
            }
        }
    }
}
```