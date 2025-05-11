```csharp
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
            Populate_DB_If_None(); // Call the method to populate the database if it doesn't exist
            GlobalConfiguration.Configure(WebApiConfig.Register); // Register the Web API routes
        }

        private static void Populate_DB_If_None()
        {
            var context = new UnishopEntities(); // Create a new instance of the database context

            if (!context.Database.Exists()) // Check if the database exists
            {
                context.Database.Create(); // Create the database if it does not exist

                // Directly connecting to the database to add a computed column to the app_unicorn table using SQL statement
                SqlConnection sqlCon = new SqlConnection(@"Data Source=db.unishop.local,1433\unishop; initial catalog=Unishop; User ID=admin; Password=dMdLgX6sZoXmOU2rnWTS;");
                SqlDataAdapter sqlda = new SqlDataAdapter("ALTER TABLE inventory ADD year_model AS (datepart(year,date_create)); ", sqlCon);
                sqlda.Fill(new DataTable()); 

                // Read the unicorn data from the unicorns.csv file
                string[] readText = File.ReadAllLines(HttpContext.Current.Server.MapPath(".") + @"\unicorns.csv");

                IList<inventory> newunicorns = new List<inventory>(); // Create a list to hold new inventory items

                // Iterate through each line in the CSV file
                foreach (var line in readText)
                {
                    string[] fields = line.Split(','); // Split the line into fields based on comma separator
                    var unicorn = new inventory(); // Create a new inventory object

                    // Populate the inventory object fields with data from the CSV
                    unicorn.unicorn_id = Guid.Parse(fields[0]);
                    unicorn.name = fields[1];
                    unicorn.description = fields[2];
                    unicorn.price = Convert.ToDecimal(fields[3]);
                    unicorn.image = fields[4];
                    unicorn.date_create = Convert.ToDateTime(fields[5]);

                    newunicorns.Add(unicorn); // Add the new unicorn to the list
                }

                context.inventories.AddRange(newunicorns); // Add all new inventory items to the context
                context.SaveChanges(); // Save changes to the database
            }
        }
    }
}
```