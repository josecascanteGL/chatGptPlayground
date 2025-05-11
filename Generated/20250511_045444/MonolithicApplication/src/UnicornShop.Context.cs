// This code is defining a namespace for the UnicornShopLegacy application
namespace UnicornShopLegacy
{
    // Importing necessary libraries for the code
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    // Defining a partial class representing the UnishopEntities, which inherits from DbContext
    public partial class UnishopEntities : DbContext
    {
        // Constructor for the UnishopEntities class which sets the connection string
        public UnishopEntities()
            : base("name=UnishopEntities")
        {
        }
    
        // Overriding the OnModelCreating method to throw an exception, preventing unintentional code-first usage
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        // Defining virtual DbSet properties for the baskets, users, and inventories
        public virtual DbSet<basket> baskets { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
    }
}