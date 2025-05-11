// This section defines the namespace UnicornShopLegacy and includes necessary libraries
namespace UnicornShopLegacy
{
    // Importing necessary libraries for working with Entity Framework
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    // Defining a partial class UnishopEntities that inherits from DbContext for database connectivity
    public partial class UnishopEntities : DbContext
    {
        // Constructor for the UnishopEntities class that specifies the database connection string
        public UnishopEntities()
            : base("name=UnishopEntities")
        {
        }
    
        // This method is called when the model for the context is being created, but it is intentionally throwing an exception here
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        // Defining virtual DbSet properties for the database tables: baskets, users, and inventories
        public virtual DbSet<basket> baskets { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
    }
}