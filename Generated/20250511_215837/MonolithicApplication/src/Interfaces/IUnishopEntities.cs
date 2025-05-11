/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * SPDX-License-Identifier: MIT-0
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify,
 * merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System; // Import system namespace
using System.Collections.Generic; // Import generic collections namespace
using System.Data.Entity; // Import Entity Framework namespace
using System.Data.Entity.Infrastructure; // Import Entity Framework infrastructure namespace
using System.Diagnostics.CodeAnalysis; // Import debugging namespace
using System.Threading.Tasks; // Import asynchronous tasks namespace

namespace UnicornShopLegacy.Interfaces // Define namespace for interface
{
    public interface IUnishopEntities : IDisposable // Define interface IUnishopEntities inheriting from IDisposable
    {
        DbSet<user> users { get; set; } // Define DbSet property for users

        DbSet<inventory> inventories { get; set; } // Define DbSet property for inventories

        DbSet<basket> baskets { get; set; } // Define DbSet property for baskets

        DbEntityEntry Entry(object entity); // Define method to get DbEntityEntry for an entity

        Task<int> SaveChangesAsync(); // Define asynchronous method to save changes

        void SetModified(object entity); // Define method to set entity as modified
    }
}