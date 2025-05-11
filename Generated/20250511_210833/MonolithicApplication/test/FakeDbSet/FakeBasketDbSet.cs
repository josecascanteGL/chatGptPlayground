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
using System.Collections.Generic;    // Importing necessary namespaces
using System.Diagnostics;   // Importing necessary namespaces
using System.Linq; // Importing necessary namespaces
using System.Text; // Importing necessary namespaces
using System.Threading.Tasks;    // Importing necessary namespaces

namespace UnicornShopLegacy.Tests
{
    internal class FakeBasketDbSet : FakeDbSet<basket> // Class declaration that extends FakeDbSet with a generic type of basket
    {
        public override basket Find(params object[] keyValues)   // Overriding the Find method with keyValues as parameter
        {
            Debug.Assert(keyValues.Length == 1, "There should be only one key for Unicorn entity");   // Assertion to check the number of key values

            var targetId = keyValues[0] as Guid?;  // Storing the key value as Guid

            if (targetId == null)   // Check if the key value is null
            {
                return null;    // Return null
            }

            var data = this.Local;  // Accessing the local data
            return data.FirstOrDefault<basket>(u => u.basket_id == targetId);    // Finding and returning the basket entity matching the targetId
        }

        public override Task<basket> FindAsync(params object[] keyValues)   // Overriding the FindAsync method
        {
            return Task.FromResult(this.Find(keyValues));    // Returning a Task with the result of Find method
        }
    }
}