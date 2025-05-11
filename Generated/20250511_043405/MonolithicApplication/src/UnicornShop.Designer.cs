// Import necessary namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicornShopLegacy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the UnicornShopEntities class
            using (var db = new UnicornShopEntities())
            {
                // Get all products from the database and store them in a list
                var products = db.Products.ToList();

                // Loop through each product in the list
                foreach (var product in products)
                {
                    // Print out the product's ID and Name
                    Console.WriteLine("Product ID: {0}, Product Name: {1}", product.Id, product.Name);
                }
            }
        }
    }
}