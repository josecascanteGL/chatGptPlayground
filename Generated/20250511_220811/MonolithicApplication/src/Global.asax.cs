/* 
 * This class represents the main entry point for the application. 
 * It checks if the database exists and populates it with data if it doesn't.
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
            // Call the method to populate the database if it is empty
            Populate_DB_If_None();
            // Initialize Web API configurations
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        // Method to populate the database if it is empty
        private static void Populate_DB_If_None()
        {
            var context = new UnishopEntities();

            // Check if the database exists
            if (!context.Database.Exists())
            {
                // Create the database if it does not exist
                context.Database.Create();

                // Directly connect to the database to add a computed column to the 'inventory' table using SQL statement
                SqlConnection sqlCon = new SqlConnection(@"Data Source=db.unishop.local,1433\unishop; initial catalog=Unishop; User ID=admin; Password=dMdLgX6sZoXmOU2rnWTS;");
                SqlDataAdapter sqlda = new SqlDataAdapter("ALTER TABLE inventory ADD year_model AS (datepart(year,date_create)); ", sqlCon);
                sqlda.Fill(new DataTable());

                // Read the content of "unicorns.csv" file
                string[] readText = File.ReadAllLines(HttpContext.Current.Server.MapPath(".") + @"\unicorns.csv");
                IList<inventory> newunicorns = new List<inventory>();

                // Iterate through the lines of the CSV file to create and add new unicorn entries to the database
                foreach (var line in readText)
                {
                    // Split each line into fields based on comma separator
                    string[] fields = line.Split(',');
                    var unicorn = new inventory();
                    unicorn.unicorn_id = Guid.Parse(fields[0]);
                    unicorn.name = fields[1];
                    unicorn.description = fields[2];
                    unicorn.price = Convert.ToDecimal(fields[3]);
                    unicorn.image = fields[4];
                    unicorn.date_create = Convert.ToDateTime(fields[5]);

                    newunicorns.Add(unicorn);
                }

                // Add newly created unicorn entries to the database and save changes
                context.inventories.AddRange(newunicorns);
                context.SaveChanges();
            }
        }
    }
}