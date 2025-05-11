// Namespace declaration for the UnicornShopLegacy project
namespace UnicornShopLegacy
{
    // Importing necessary libraries for the code
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    // Defining a partial class UnishopEntities that inherits from DbContext
    public partial class UnishopEntities : DbContext
    {
        // Constructor for UnishopEntities, specifying the connection string
        public UnishopEntities()
            : base("name=UnishopEntities")
        {
            // No logic in the constructor
        }

        // Override method for OnModelCreating, throwing an exception
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        // Declaring DbSet properties for the database tables
        public virtual DbSet<basket> baskets { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
    }
}