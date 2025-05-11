// Copyright notice and license information

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace UnicornShopLegacy.Interfaces
{
    // Define an interface for the Unicorn Shop entities, inheriting from IDisposable
    public interface IUnishopEntities : IDisposable
    {
        // Define property to access user data in the database
        DbSet<user> users { get; set; }

        // Define property to access inventory data in the database
        DbSet<inventory> inventories { get; set; }

        // Define property to access basket data in the database
        DbSet<basket> baskets { get; set; }

        // Get the DbEntityEntry for a specific entity
        DbEntityEntry Entry(object entity);

        // Save changes asynchronously and return the number of affected objects
        Task<int> SaveChangesAsync();

        // Set the state of an entity as modified
        void SetModified(object entity);
    }
}