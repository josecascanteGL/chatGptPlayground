// Include the necessary using directives to access Entity Framework classes
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UnicornShopLegacy
{
    public class UnicornShopLegacyContext : DbContext
    {
        // Constructor that passes the connection string to the base DbContext class
        public UnicornShopLegacyContext() : base("name=UnicornShopLegacyContext")
        {
        }

        // Define a DbSet property for the Unicorn entity
        public virtual DbSet<Unicorn> Unicorns { get; set; }
    }

    // Define the Unicorn entity class with properties representing columns in the database table
    public class Unicorn
    {
        public int Id { get; set; } // Primary key Id
        public string Name { get; set; } // Name of the unicorn
        public int Age { get; set; } // Age of the unicorn
        public decimal Price { get; set; } // Price of the unicorn
    }
}