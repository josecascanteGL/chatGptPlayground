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
            // Call Populate_DB_If_None method when the application starts
            Populate_DB_If_None();
            // Register the Web API configurations
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private static void Populate_DB_If_None()
        {
            // Create a new instance of the UnishopEntities context
            var context = new UnishopEntities();

            // Check if the database does not exist
            if (!context.Database.Exists())
            {
                // Create the database if it does not exist
                context.Database.Create();

                // Establish a direct SQL connection to the database to add a computed column 'year_model' to the 'inventory' table
                SqlConnection sqlCon = new SqlConnection(@"Data Source=db.unishop.local,1433\unishop; initial catalog=Unishop; User ID=admin; Password=dMdLgX6sZoXmOU2rnWTS;");
                SqlDataAdapter sqlda = new SqlDataAdapter("ALTER TABLE inventory ADD year_model AS (datepart(year,date_create)); ", sqlCon);
                
                // Execute the SQL command to add the computed column
                sqlda.Fill(new DataTable());
                
                // Read the contents of the unicorns.csv file
                string[] readText = File.ReadAllLines(HttpContext.Current.Server.MapPath(".") + @"\unicorns.csv");
                
                // Create a list to store the new unicorn inventory items
                IList<inventory> newunicorns = new List<inventory>();
                
                // Iterate through each line in the csv file
                foreach (var line in readText)
                {
                    // Split the line by comma to extract individual fields
                    string[] fields = line.Split(',');
                    
                    // Create a new inventory item and populate its properties from the csv fields
                    var unicorn = new inventory();
                    unicorn.unicorn_id = Guid.Parse(fields[0]);
                    unicorn.name = fields[1];
                    unicorn.description = fields[2];
                    unicorn.price = Convert.ToDecimal(fields[3]);
                    unicorn.image = fields[4];
                    unicorn.date_create = Convert.ToDateTime(fields[5]);
                    
                    // Add the new unicorn item to the list
                    newunicorns.Add(unicorn);
                }

                // Add all the new unicorn items to the database context
                context.inventories.AddRange(newunicorns);
                
                // Save changes to the database
                context.SaveChanges();
            }
        }
    }
}
```