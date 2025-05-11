// Include necessary namespaces for the program
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
            // Create a new instance of the UnicornShopEntities class, which represents the database context
            using (var db = new UnicornShopEntities())
            {
                // Retrieve all products from the Products table in the database
                var products = db.Products.ToList();

                // Iterate through each product in the products list
                foreach (var product in products)
                {
                    // Print the product name and price to the console
                    Console.WriteLine($"Product Name: {product.Name}, Price: {product.Price}");
                }
            }
        }
    }
}