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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace UnicornShopLegacy.Tests
{
    internal class FakeDbSet<T> : DbSet<T>, IDbSet<T>
        where T : class
    {
        private readonly List<T> data;

        public FakeDbSet()
        {
            // Initialize an empty list to hold the data
            this.data = new List<T>();
        }

        // Implements IQueryable interface Expression property
        Expression IQueryable.Expression
        {
            get { return this.data.AsQueryable().Expression; }
        }

        // Implements IQueryable interface Provider property
        IQueryProvider IQueryable.Provider
        {
            get { return this.data.AsQueryable().Provider; }
        }

        // Exposes the internal list data
        public List<T> Local
        {
            get { return this.data; }
        }

        // Implements IQueryable interface ElementType property
        Type IQueryable.ElementType
        {
            get { return this.data.AsQueryable().ElementType; }
        }

        // Override Find method
        public override T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        // Override Add method
        public override T Add(T item)
        {
            // Add the item to the internal list
            this.data.Add(item);
            return item;
        }

        // Override Remove method
        public override T Remove(T item)
        {
            // Remove the item from the internal list
            this.data.Remove(item);
            return item;
        }

        // Override Attach method
        public override T Attach(T item)
        {
            // Explicitly return null
            return null;
        }

        // Custom Detach method to remove an item
        public T Detach(T item)
        {
            this.data.Remove(item);
            return item;
        }

        // Override Create method to instantiate a new object of type T
        public override T Create()
        {
            return Activator.CreateInstance<T>();
        }

        // Create method for derived entities
        public TDerivedEntity Create<TDerivedEntity>()
            where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        // Override AddRange method to add a collection of entities
        public override IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            // Add all entities to the internal list
            this.data.AddRange(entities);
            return this.data;
        }

        // Override RemoveRange method to remove a collection of entities
        public override IEnumerable<T> RemoveRange(IEnumerable<T> entities)
        {
            // Iterate over entities in reverse order to safely remove and maintain indices
            for (int i = entities.Count() - 1; i >= 0; i--)
            {
                T entity = entities.ElementAt(i);
                // Check if the entity exists in the internal list and remove it
                if (this.data.Contains(entity))
                {
                    this.Remove(entity);
                }
            }

            // Return the updated list of entities
            return this;
        }

        // Implement non-generic IEnumerable GetEnumerator method
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        // Implement generic IEnumerable<T> GetEnumerator method
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }
    }
}