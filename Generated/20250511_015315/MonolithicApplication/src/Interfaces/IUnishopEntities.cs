// The following code defines an interface IUnishopEntities that represents a data context for the UnicornShopLegacy application.
// The interface provides access to DbSet properties for the 'users', 'inventories', and 'baskets' entities.
// It also includes methods such as Entry, SaveChangesAsync, and SetModified for interacting with the data context.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace UnicornShopLegacy.Interfaces
{
    public interface IUnishopEntities : IDisposable
    {
        // DbSet property for the 'users' entity
        DbSet<user> users { get; set; }

        // DbSet property for the 'inventories' entity
        DbSet<inventory> inventories { get; set; }

        // DbSet property for the 'baskets' entity
        DbSet<basket> baskets { get; set; }

        // Method to get DbEntityEntry for a specific entity
        DbEntityEntry Entry(object entity);

        // Asynchronous method to save changes to the data context
        Task<int> SaveChangesAsync();

        // Method to set the state of a specific entity as modified
        void SetModified(object entity);
    }
}