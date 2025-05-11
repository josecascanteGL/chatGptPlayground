// Include necessary libraries for Entity Framework
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UnicornShop
{
    public class UnicornShopContext : DbContext
    {
        // Constructor for UnicornShopContext class
        public UnicornShopContext() : base("name=UnicornShopEntities") { }

        // Define DbSet for Unicorn entity
        public DbSet<Unicorn> Unicorns { get; set; }

        // Define DbSet for Shop entity
        public DbSet<Shop> Shops { get; set; }

        // Define DbSet for Product entity
        public DbSet<Product> Products { get; set; }

        // Define DbSet for Order entity
        public DbSet<Order> Orders { get; set; }

        // Define DbSet for Customer entity
        public DbSet<Customer> Customers { get; set; }
    }
}