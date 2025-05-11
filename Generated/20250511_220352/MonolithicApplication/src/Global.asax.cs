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
            Populate_DB_If_None();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private static void Populate_DB_If_None()
        {
            // Creating a new instance of UnishopEntities to interact with the database
            var context = new UnishopEntities();

            // Checking if the database exists, if not, create one and populate it with unicorn data
            if (!context.Database.Exists())
            {
                context.Database.Create();

                // Establishing a direct SQL connection to the database to add a computed column 'year_model' to the 'inventory' table
                SqlConnection sqlCon = new SqlConnection(@"Data Source=db.unishop.local,1433\unishop; initial catalog=Unishop; User ID=admin; Password=dMdLgX6sZoXmOU2rnWTS;");
                SqlDataAdapter sqlda = new SqlDataAdapter("ALTER TABLE inventory ADD year_model AS (datepart(year,date_create)); ", sqlCon);
                sqlda.Fill(new DataTable());

                // Reading a CSV file containing unicorn information and adding each unicorn to the database
                string[] readText = File.ReadAllLines(HttpContext.Current.Server.MapPath(".") + @"\unicorns.csv");
                IList<inventory> newunicorns = new List<inventory>();
                foreach (var line in readText)
                {
                    // Splitting each line of the CSV file to extract unicorn details
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

                // Adding the new unicorn data to the database and saving changes
                context.inventories.AddRange(newunicorns);
                context.SaveChanges();
            }
        }
    }
}