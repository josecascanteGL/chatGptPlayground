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

        // Constructor to initialize the internal list of data
        public FakeDbSet()
        {
            this.data = new List<T>();
        }

        // Retrieves the expression of the data when queried
        Expression IQueryable.Expression
        {
            get { return this.data.AsQueryable().Expression; }
        }

        // Retrieves the query provider for the data
        IQueryProvider IQueryable.Provider
        {
            get { return this.data.AsQueryable().Provider; }
        }

        // Gets the local list of data
        public List<T> Local
        {
            get { return this.data; }
        }

        // Retrieves the element type of the data
        Type IQueryable.ElementType
        {
            get { return this.data.AsQueryable().ElementType; }
        }

        // Overrides the Find method and throws an exception
        public override T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        // Adds an item to the data list
        public override T Add(T item)
        {
            this.data.Add(item);
            return item;
        }

        // Removes an item from the data list
        public override T Remove(T item)
        {
            this.data.Remove(item);
            return item;
        }

        // Attaches an item to the data (not implemented)
        public override T Attach(T item)
        {
            return null;
        }

        // Detaches an item from the data
        public T Detach(T item)
        {
            this.data.Remove(item);
            return item;
        }

        // Creates an instance of the entity type
        public override T Create()
        {
            return Activator.CreateInstance<T>();
        }

        // Creates an instance of a derived entity type
        public TDerivedEntity Create<TDerivedEntity>()
            where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        // Adds a range of entities to the data list
        public override IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            this.data.AddRange(entities);
            return this.data;
        }

        // Removes a range of entities from the data list
        public override IEnumerable<T> RemoveRange(IEnumerable<T> entities)
        {
            for (int i = entities.Count() - 1; i >= 0; i--)
            {
                T entity = entities.ElementAt(i);
                if (this.data.Contains(entity))
                {
                    this.Remove(entity);
                }
            }

            return this;
        }

        // Returns an enumerator for the data list
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        // Returns an typed enumerator for the data list
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }
    }
}
