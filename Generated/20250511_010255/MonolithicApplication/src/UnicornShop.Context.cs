```c#
namespace UnicornShopLegacy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    // Define a partial class UnishopEntities that inherits from DbContext
    public partial class UnishopEntities : DbContext
    {
        // Constructor for UnishopEntities that sets the connection string to "UnishopEntities"
        public UnishopEntities()
            : base("name=UnishopEntities")
        {
        }
    
        // Override OnModelCreating method to throw an exception
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        // Define virtual properties for DbSet of baskets, users, and inventories
        public virtual DbSet<basket> baskets { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
    }
}
```
In this code:
- The `UnishopEntities` class is defined as a partial class that inherits from `DbContext`.
- The constructor of `UnishopEntities` sets the connection string to "UnishopEntities".
- The `OnModelCreating` method is overridden to throw an exception, preventing unintentional code-first migrations.
- Virtual properties are defined for `DbSet` of `basket`, `user`, and `inventory` entities.