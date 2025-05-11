
// Import necessary namespaces
// Global namespace
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
            // Check and populate the database if it does not exist
            Populate_DB_If_None();
            
            // Configure global web API routes
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        // Ensure database is populated with initial data if it does not exist
        private static void Populate_DB_If_None()
        {
            // Create a new instance of the UnishopEntities context
            var context = new UnishopEntities();

            // Check if the database exists
            if (!context.Database.Exists())
            {
                // Create the database if it does not exist
                context.Database.Create();

                // Establish a connection to the database using a SQL connection string
                SqlConnection sqlCon = new SqlConnection(@"Data Source=db.unishop.local,1433\unishop; initial catalog=Unishop; User ID=admin; Password=dMdLgX6sZoXmOU2rnWTS;");

                // Execute a SQL statement to add a computed column to the inventory table
                SqlDataAdapter sqlda = new SqlDataAdapter("ALTER TABLE inventory ADD year_model AS (datepart(year,date_create)); ", sqlCon);
                sqlda.Fill(new DataTable());

                // Read and process data from a CSV file containing unicorn information
                string[] readText = File.ReadAllLines(HttpContext.Current.Server.MapPath(".") + @"\unicorns.csv");
                IList<inventory> newunicorns = new List<inventory>();
                foreach (var line in readText)
                {
                    // Split each line of the CSV file into fields
                    string[] fields = line.Split(',');

                    // Create a new inventory object and populate its properties
                    var unicorn = new inventory();
                    unicorn.unicorn_id = Guid.Parse(fields[0]);
                    unicorn.name = fields[1];
                    unicorn.description = fields[2];
                    unicorn.price = Convert.ToDecimal(fields[3]);
                    unicorn.image = fields[4];
                    unicorn.date_create = Convert.ToDateTime(fields[5]);

                    // Add the new unicorn object to the list
                    newunicorns.Add(unicorn);
                }

                // Add the new unicorn data to the context and save changes to the database
                context.inventories.AddRange(newunicorns);
                context.SaveChanges();
            }
        }
    }
}